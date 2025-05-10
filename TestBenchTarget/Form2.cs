using Newtonsoft.Json;
using System.ComponentModel;

namespace TestBenchTarget
{
    public partial class Form2 : Form
    {
        private BindingSource bindingSource;
        private CustomBindingList<DataItem> dataList;
        private System.Windows.Forms.Timer timer; // windows forms timer
        private bool isHandlingDataError = false;
        private bool isUpdatingUI = false;
        private bool isDeleting = false;
        private bool isClearing = false;
        private static bool isAdding = false;
        private System.Windows.Forms.Timer updateTimer;


        public Form2()
        {
            InitializeComponent();

            // Initialize non-nullable fields to avoid CS8618 warnings
            bindingSource = new BindingSource();
            dataList = new CustomBindingList<DataItem>();
            updateTimer = new System.Windows.Forms.Timer();

            // 1. Základná inicializácia UI
            // Initialize time and date
            LabelTime.Text = DateTime.Now.ToString("HH:mm:ss");

            // Setup timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) =>
            {
                LabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();

            // 2. Nastavenie DPI-špecifických úprav pre UI - Set DPI-specific UI adjustments
            ConfigureUIForHighDpi();

            // 3. Inicializácia dátového zdroja - Initialize data source
            InitializeDataSource();

            // 4. Inicializácia kontroliek a eventov - Initialize controls and events
            InitializeControls();


        }

        // Metóda pre konfiguráciu UI podľa aktuálneho DPI - Configure UI for current DPI
        private void ConfigureUIForHighDpi()
        {
            // 1. Základné nastavenia pre DataGridView - Configure DataGridView
            ConfigureDataGridViewBasics();

            // 2. Vypočítanie škálovacieho faktora na základe DPI - Calculate scale factor based on DPI
            float scaleFactor = CalculateScaleFactor();

            // 3. Aplikácia škálovania na všetky relevantné UI elementy - Apply scaling to all relevant UI elements
            if (scaleFactor < 1.0f)
            {
                // DataGridView úpravy - Adjust DataGridView
                AdjustDataGridViewForHighDpi(scaleFactor);

                // Úpravy pre vstupné kontrolky - Adjust input controls
                AdjustInputControlsForHighDpi(scaleFactor);

                // Úpravy pre tlačidlá - Adjust buttons
                AdjustButtonsForHighDpi(scaleFactor);

                // Úpravy pre ostatné UI elementy - Adjust other UI elements
                AdjustOtherUIElementsForHighDpi(scaleFactor);
            }
        }

        // Základné nastavenia pre DataGridView - Configure DataGridView basics
        private void ConfigureDataGridViewBasics()
        {
            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.AllowUserToAddRows = true;
            DataGridView1.AllowUserToDeleteRows = true;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.MultiSelect = false;

            // Nastavenie pre NullValue - DefaultCellStyle
            ColumnPoints.DefaultCellStyle.NullValue = 0;
            ColumnDate.DefaultCellStyle.NullValue = DateTime.Now.Date;
            ColumnDate.DefaultCellStyle.Format = "dd.MM.yyyy";

            // Nastavenie režimu zarovnania stĺpcov na Fill pre lepšie prispôsobenie - Set column fill mode
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Výpočet škálovacieho faktora na základe DPI - Calculate scale factor based on DPI
        private float CalculateScaleFactor()
        {
            if (DeviceDpi >= 240) // 250% alebo vyššie - 250% or higher
            {
                return 0.75f;
            }
            else if (DeviceDpi >= 192) // 200% scaling
            {
                return 0.85f;
            }
            else if (DeviceDpi >= 144) // 150% scaling
            {
                return 0.9f;
            }
            else if (DeviceDpi > 96) // 125% scaling
            {
                return 0.95f;
            }
            return 1.0f; // standard scaling (100% or lower)
        }

        // Úpravy pre DataGridView pri vysokom DPI - Adjust DataGridView for high DPI
        private void AdjustDataGridViewForHighDpi(float scaleFactor)
        {
            // Upraviť font pre bunky - Adjust font for cells
            DataGridView1.DefaultCellStyle.Font = new Font(
                DataGridView1.DefaultCellStyle.Font.FontFamily,
                DataGridView1.DefaultCellStyle.Font.Size * scaleFactor,
                DataGridView1.DefaultCellStyle.Font.Style);

            // Upraviť font pre hlavičky stĺpcov - Adjust font for column headers
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(
                DataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily,
                DataGridView1.ColumnHeadersDefaultCellStyle.Font.Size * scaleFactor,
                DataGridView1.ColumnHeadersDefaultCellStyle.Font.Style);

            // Nastavenie výšky riadkov - pri vysokom DPI to môže pomôcť - Set row height
            DataGridView1.RowTemplate.Height = (int)(DataGridView1.RowTemplate.Height * (1.0f + (1.0f - scaleFactor)));

            // Nastavenie výšky hlavičky stĺpcov - Set column header height
            DataGridView1.ColumnHeadersHeight = (int)(DataGridView1.ColumnHeadersHeight * (1.0f + (1.0f - scaleFactor)));
        }

        // Úpravy pre vstupné kontrolky pri vysokom DPI - Adjust input controls for high DPI
        private void AdjustInputControlsForHighDpi(float scaleFactor)
        {
            // Upraviť výšku textových polí pre lepšiu viditeľnosť - Adjust height of text boxes
            int textBoxHeight = (int)(TextBoxProcedure.Height * (1.0f + (1.0f - scaleFactor)));

            // Zväčšenie výšky textových polí a DomainUpDown - Increase height of text boxes and DomainUpDown
            TextBoxProcedure.Height = textBoxHeight;
            TextBoxPoints.Height = textBoxHeight;
            TextBoxDelegate.Height = textBoxHeight;
            DomainUpDownDate.Height = textBoxHeight;

            // Upraviť fonty pre lepšiu čitateľnosť - Adjust font for better readability
            Font adjustedFont = new Font(
                TextBoxProcedure.Font.FontFamily,
                TextBoxProcedure.Font.Size * scaleFactor,
                TextBoxProcedure.Font.Style);

            TextBoxProcedure.Font = adjustedFont;
            TextBoxPoints.Font = adjustedFont;
            TextBoxDelegate.Font = adjustedFont;
            DomainUpDownDate.Font = adjustedFont;

            // Upraviť aj fonty pre popisky - Adjust font for labels
            Font labelFont = new Font(
                LabelDate.Font.FontFamily,
                LabelDate.Font.Size * scaleFactor,
                LabelDate.Font.Style);

            LabelDate.Font = labelFont;
            LabelProcedure.Font = labelFont;
            LabelPoints.Font = labelFont;
            LabelDelegate.Font = labelFont;
            LabelTime.Font = labelFont;
        }

        // Úpravy pre tlačidlá pri vysokom DPI - Adjust buttons for high DPI
        private void AdjustButtonsForHighDpi(float scaleFactor)
        {
            // Zväčšenie výšky tlačidiel pre lepšiu použiteľnosť na dotykových zariadeniach - Increase button height
            int buttonHeight = (int)(ButtonAddDate.Height * (1.0f + (1.0f - scaleFactor)));

            // Upraviť fonty pre tlačidlá - Adjust font for buttons
            Font buttonFont = new Font(
                ButtonAddDate.Font.FontFamily,
                ButtonAddDate.Font.Size * scaleFactor,
                ButtonAddDate.Font.Style);

            // Aplikácia úprav na všetky tlačidlá - Apply adjustments to all buttons
            Button[] buttons = {
                ButtonAddDate, ButtonLoadData, ButtonSaveData,
                ButtonRemove, ButtonOpenFolder
            };

            foreach (Button button in buttons)
            {
                button.Height = buttonHeight;
                button.Font = buttonFont;
            }
        }

        // Úpravy pre ostatné UI elementy pri vysokom DPI - Adjust other UI elements for high DPI
        private void AdjustOtherUIElementsForHighDpi(float scaleFactor)
        {
            if (DeviceDpi >= 240)
            {
                // Väčšie rozostupy medzi popiskami a textboxami - Increase spacing between labels and textboxes
                LabelDate.Top = DomainUpDownDate.Top - 20;
                LabelProcedure.Top = TextBoxProcedure.Top - 20;
                LabelPoints.Top = TextBoxPoints.Top - 20;
                LabelDelegate.Top = TextBoxDelegate.Top - 20;

                // Väčšie rozostupy medzi tlačidlami - Increase spacing between buttons
                ButtonLoadData.Top = ButtonAddDate.Bottom + 15;
                ButtonSaveData.Top = ButtonLoadData.Bottom + 15;
                ButtonRemove.Top = ButtonSaveData.Bottom + 15;
                ButtonOpenFolder.Top = ButtonRemove.Bottom + 15;
            }
        }

        // Metóda pre inicializáciu dátového zdroja - Initialize data source
        private void InitializeDataSource()
        {
            // Initialize data source
            dataList = new CustomBindingList<DataItem>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataList;

            // Setup column mapping
            ColumnDate.DataPropertyName = "DateColumnValue";
            ColumnProcedure.DataPropertyName = "ProcedureColumnValue";
            ColumnPoints.DataPropertyName = "PointsColumnValue";
            ColumnDelegate.DataPropertyName = "DelegateColumnValue";

            // Connect DataGridView to data source
            DataGridView1.DataSource = bindingSource;
        }

        // Metóda pre inicializáciu kontroliek a event handlerov - Initialize controls and event handlers
        private void InitializeControls()
        {
            // Initialize DomainUpDown
            InitializeDomainUpDown();

            // Priradenie event handlerov pre DataGridView - Assign event handlers for DataGridView
            DataGridView1.DataError += DataGridView1_DataError!;
            DataGridView1.CellParsing += DataGridView1_CellParsing!;
            DataGridView1.RowsAdded += DataGridView1_RowsAdded!;
            DataGridView1.SelectionChanged += DataGridView1_SelectionChanged!;
            DataGridView1.CellValidating += DataGridView1_CellValidating!;
            DataGridView1.CellEndEdit += DataGridView1_CellEndEdit!;

            // Nastavenie updateTimer - Initialize updateTimer
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 500; // 500 ms delay
            updateTimer.Tick += UpdateTimer_Tick!;

            // Priradenie event handlerov pre TextBox a DomainUpDown - Assign event handlers for TextBox and DomainUpDown
            TextBoxProcedure.TextChanged += TextBox_TextChanged!;
            TextBoxPoints.TextChanged += TextBoxPoints_TextChanged_New!;
            TextBoxDelegate.TextChanged += TextBox_TextChanged!;
            TextBoxPoints.KeyPress += TextBoxPoints_KeyPress!;
            TextBoxPoints.LostFocus += TextBoxPoints_LostFocus!;
            DomainUpDownDate.KeyDown += DomainUpDownDate_KeyDown!;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            if (updateTimer != null)
            {
                updateTimer.Stop();
                updateTimer.Dispose();
            }

            base.OnFormClosing(e);
        }

        // Initialize DomainUpDown with dates
        private void InitializeDomainUpDown()
        {
            // days into DomainUpDownDate
            for (int i = -367; i <= 367; i++)
            {
                DateTime date = DateTime.Now.AddDays(-i);
                DomainUpDownDate.Items.Add(date.ToString("dd.MM.yyyy"));
            }
            // Set current date as default (it's in the middle of the list)
            DomainUpDownDate.SelectedIndex = 367; // Index of current day (at position in the middle)

            // Prevent direct editing by user to avoid invalid formats
            DomainUpDownDate.ReadOnly = true;
        }

        private void TextBoxPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  to LostFocus()
            // allow all characters but only digits and control keys (backspace, delete, etc.) will be used for conversion
        }

        private void TextBoxPoints_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxPoints.Text) ||
                !int.TryParse(TextBoxPoints.Text, out _))
            {
                if (TextBoxPoints.Text != "0")
                {
                    TextBoxPoints.Text = "0";
                }
            }
        }

        private void ButtonAddDate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ButtonAddDate_Click called");
            if (isAdding) return;
            isAdding = true;

            try
            {
                Console.WriteLine("Adding date...");
                // Parse date with validation
                string dateString = DomainUpDownDate.SelectedItem?.ToString()!;

                if (string.IsNullOrEmpty(dateString))
                {
                    dateString = DateTime.Now.ToString("dd.MM.yyyy");
                    DomainUpDownDate.SelectedItem = dateString;
                }

                DateTime selectedColumnDate = DateTime.Now.Date;
                IsValidDate(dateString, out selectedColumnDate);

                // Get values from textboxes
                string procedureColumnValue = TextBoxProcedure.Text;

                int pointsColumnValue = 0;
                if (!string.IsNullOrEmpty(TextBoxPoints.Text))
                {
                    if (!int.TryParse(TextBoxPoints.Text, out pointsColumnValue))
                    {
                        Console.WriteLine($"Invalid points value: {TextBoxPoints.Text}");
                        pointsColumnValue = 0;
                    }
                }
                Console.WriteLine($"Parsed points value: {pointsColumnValue}");
                string delegateColumnValue = TextBoxDelegate.Text;

                // Create and add new record
                DataItem newItem = new DataItem
                {
                    DateColumnValue = selectedColumnDate,
                    ProcedureColumnValue = procedureColumnValue,
                    PointsColumnValue = pointsColumnValue,
                    DelegateColumnValue = delegateColumnValue
                };
                Console.WriteLine($"New item created: {newItem.DateColumnValue}, {newItem.ProcedureColumnValue}, {newItem.PointsColumnValue}, {newItem.DelegateColumnValue}");
                // Add new record
                dataList.Add(newItem);

                // Set focus back to DomainUpDownDate
                DomainUpDownDate.Focus();

                //  After adding 
                if (DataGridView1.Rows.Count > 0)
                {
                    DataGridView1.ClearSelection();
                    DataGridView1.Rows[0].Selected = true;
                    DataGridView1.CurrentCell = DataGridView1.Rows[0].Cells[0];
                    DataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    if (DataGridView1.CurrentRow != null)
                    {
                        DataGridView1.CurrentRow.Selected = true;
                        if (DataGridView1.CurrentRow.Cells.Count > 0)
                        {
                            DataGridView1.CurrentRow.Cells[0].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding date: {ex.Message}");
                MessageBox.Show($"Add date error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isAdding = false;
            }
        }

        private void ClearTextBoxes()
        {
            isClearing = true; //  flag
            try
            {
                TextBoxProcedure.Text = string.Empty;
                TextBoxPoints.Text = string.Empty;
                TextBoxDelegate.Text = string.Empty;
            }
            finally
            {
                isClearing = false;
            }
        }

        // Method for handling key press in DomainUpDownDate
        private void DomainUpDownDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Prevent further processing of the event
                e.SuppressKeyPress = true; // Prevent beep
                ButtonAddDate_Click(this, EventArgs.Empty);
            }
        }

        // Main method for adding date to DataGridView
        private void AddDateToDataGrid()
        {
            string dateString = DomainUpDownDate.SelectedItem?.ToString()!;

            if (string.IsNullOrEmpty(dateString))
            {
                MessageBox.Show("Please select a valid date.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Parse date with validation
                if (!IsValidDate(dateString, out DateTime selectedDate))
                {
                    MessageBox.Show($"Invalid date format: {dateString}. Please use dd.MM.yyyy format.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and add new record
                DataItem newItem = new DataItem
                {
                    DateColumnValue = selectedDate,
                    // Leave other fields empty or with default values
                };

                // Add new record to the beginning of the list
                dataList.Add(newItem);

                // Set focus back to DomainUpDownDate for next input
                DomainUpDownDate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add date error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Ensure the first row is always visible
            if (DataGridView1.Rows.Count > 0)
            {
                DataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        public class DataItem : INotifyPropertyChanged
        {
            private DateTime dateColumnValue = DateTime.Now;
            private string procedureColumnValue = string.Empty;
            private int pointsColumnValue;
            private string delegateColumnValue = string.Empty;

            public event PropertyChangedEventHandler? PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public DateTime DateColumnValue
            {
                get => dateColumnValue;
                set
                {
                    if (dateColumnValue != value.Date)
                    {
                        dateColumnValue = value.Date;
                        OnPropertyChanged(nameof(DateColumnValue));
                    }
                }
            }

            public string ProcedureColumnValue
            {
                get => procedureColumnValue;
                set
                {
                    if (procedureColumnValue != value)
                    {
                        procedureColumnValue = value;
                        OnPropertyChanged(nameof(ProcedureColumnValue));
                    }
                }
            }

            public int PointsColumnValue
            {
                get => pointsColumnValue;
                set
                {
                    if (pointsColumnValue != value)
                    {
                        pointsColumnValue = value;
                        OnPropertyChanged(nameof(PointsColumnValue));
                    }
                }
            }

            public string DelegateColumnValue // Updated property name to match the renamed field
            {
                get => delegateColumnValue;
                set
                {
                    if (delegateColumnValue != value)
                    {
                        delegateColumnValue = value;
                        OnPropertyChanged(nameof(DelegateColumnValue));
                    }
                }
            }
        }

        // Custom implementation of BindingList
        public class CustomBindingList<T> : BindingList<T>
        {
            protected override void InsertItem(int index, T item)
            {
                // Always insert at the beginning of the list
                base.InsertItem(0, item);
            }
        }

        // Method for removing selected record
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ButtonRemove_Click called");
            // Prevent duplicate calls
            if (isDeleting) return;
            isDeleting = true;

            try
            {
                Console.WriteLine("Removing selected rows...");
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    // Disable UI during deletion
                    DataGridView1.Enabled = false;

                    // First get CurrencyManager for bindingSource
                    CurrencyManager currencyManager =
                        (CurrencyManager)BindingContext![bindingSource];

                    // Temporarily suspend binding to prevent errors
                    currencyManager.SuspendBinding();

                    // Collect indexes of selected rows
                    List<int> selectedIndexes = new List<int>();
                    foreach (DataGridViewRow row in DataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowIndex = row.Index;
                            if (rowIndex >= 0 && rowIndex < dataList.Count)
                            {
                                Console.WriteLine($"Row index: {rowIndex}");
                                selectedIndexes.Add(rowIndex);
                            }
                        }
                    }

                    // If no valid rows are selected, end
                    if (selectedIndexes.Count == 0)
                    {
                        Console.WriteLine("No valid rows selected.");
                        MessageBox.Show("No valid rows selected.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        currencyManager.ResumeBinding();
                        DataGridView1.Enabled = true;
                        return;
                    }

                    Console.WriteLine($"Selected indexes: {string.Join(", ", selectedIndexes)}");

                    // Disconnect DataSource before changing data
                    DataGridView1.DataSource = null;

                    // Sort indexes in descending order to remove from end first
                    selectedIndexes.Sort();
                    selectedIndexes.Reverse();

                    // Remove items from end to keep indexes consistent
                    foreach (int index in selectedIndexes)
                    {
                        if (index >= 0 && index < dataList.Count)
                        {
                            dataList.RemoveAt(index);
                        }
                    }

                    // Reconnect data source
                    bindingSource.DataSource = dataList;
                    DataGridView1.DataSource = bindingSource;

                    Console.WriteLine("Rebinding DataGridView...");
                    // Re-setup column mapping
                    DataGridView1.AutoGenerateColumns = false;
                    ColumnDate.DataPropertyName = "DateColumnValue";
                    ColumnDate.DefaultCellStyle.Format = "dd.MM.yyyy";
                    ColumnProcedure.DataPropertyName = "ProcedureColumnValue";
                    ColumnPoints.DataPropertyName = "PointsColumnValue";
                    ColumnDelegate.DataPropertyName = "DelegateColumnValue";

                    // Restore binding functionality
                    currencyManager.ResumeBinding();

                    Console.WriteLine("Resetting bindings...");
                    // Apply items
                    bindingSource.ResetBindings(false);
                    DataGridView1.Refresh();

                    // Re-enable UI
                    DataGridView1.Enabled = true;

                    // Clear selection and verify we have valid selection
                    if (DataGridView1.Rows.Count > 0)
                    {
                        DataGridView1.ClearSelection();
                        DataGridView1.Rows[0].Selected = true;
                        DataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
                else
                {
                    Console.WriteLine("No row selected to delete.");
                    MessageBox.Show("No row selected to delete.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing rows: {ex.Message}");
                MessageBox.Show($"Error removing rows: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Console.WriteLine("Finished removing rows.");
                isDeleting = false;
                DataGridView1.Enabled = true;
            }
        }

        // Method for adding/updating data from textboxes to DataGridView
        private void LabelsToDataGridView(object sender, EventArgs e)
        {
            // If UI changes are already in progress, do nothing
            if (isClearing || isUpdatingUI) return;
            isUpdatingUI = true;

            try
            {
                // Store sender as TextBox and remember cursor position
                TextBox? textBox = sender as TextBox;
                int cursorPosition = -1;
                if (textBox != null)
                {
                    cursorPosition = textBox.SelectionStart;
                }

                // Get values from textboxes
                string procedureColumnValue = TextBoxProcedure.Text ?? string.Empty;
                string pointsText = TextBoxPoints.Text ?? string.Empty;
                string delegateColumnValue = TextBoxDelegate.Text ?? string.Empty;

                // Convert points to number, always defaulting to 0 for invalid/empty values
                int pointsColumnValue = 0;
                if (!string.IsNullOrWhiteSpace(pointsText))
                {
                    if (!int.TryParse(pointsText, out pointsColumnValue))
                    {
                        pointsColumnValue = 0;
                    }
                }

                // If we have a selected row in DataGridView, update it
                if (DataGridView1.CurrentRow != null && !DataGridView1.CurrentRow.IsNewRow)
                {
                    int rowIndex = DataGridView1.CurrentRow.Index;
                    if (rowIndex >= 0 && rowIndex < dataList.Count)
                    {
                        // Update existing record
                        dataList[rowIndex].ProcedureColumnValue = procedureColumnValue;
                        dataList[rowIndex].PointsColumnValue = pointsColumnValue;
                        dataList[rowIndex].DelegateColumnValue = delegateColumnValue;

                        // Refresh binding source to reflect changes in UI
                        bindingSource.ResetBindings(false);
                    }
                }

                // Restore cursor position
                if (textBox != null && cursorPosition != -1)
                {
                    textBox.SelectionStart = cursorPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LabelsToDataGridView: {ex.Message}");
            }
            finally
            {
                isUpdatingUI = false;
            }
        }

        // Method for displaying selected record in textboxes
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentRow != null && !DataGridView1.CurrentRow.IsNewRow)
            {
                int rowIndex = DataGridView1.CurrentRow.Index;
                if (rowIndex >= 0 && rowIndex < dataList.Count)
                {
                }
            }
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            // Open Windows Explorer general folder
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
        }

        // Save data to JSON file - Newtonsoft.Json
        private void SaveDataToJson(string filePath)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(dataList, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    var loadedData = JsonConvert.DeserializeObject<List<DataItem>>(jsonData)!;

                    // Clear existing data
                    dataList.Clear();

                    // Add loaded data
                    foreach (var item in loadedData)
                    {
                        dataList.Add(item);
                    }

                    // Refresh UI
                    bindingSource.ResetBindings(false);
                    MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true; // stop of standard behavior
                ButtonRemove_Click(this, EventArgs.Empty);
            }
        }

        private void ButtonSaveData_Click(object sender, EventArgs e)
        {
            SaveDataWithDialog();
        }

        private void ButtonLoadData_Click(object sender, EventArgs e)
        {
            QuickLoadData();
        }

        // Default name and path to file
        private string GetDefaultJsonFilePath()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documentsFolder, "TestBenchTarget.json");
        }

        // Method for quick save to default file
        private void QuickSaveData()
        {
            string defaultPath = GetDefaultJsonFilePath();
            SaveDataToJson(defaultPath);
        }

        private void SaveDataWithDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) //= Nullable 
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Data As";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.FileName = "TestBenchTarget.json";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveDataToJson(saveFileDialog.FileName);
                }
            }
        }

        private void QuickLoadData()
        {
            string defaultPath = GetDefaultJsonFilePath();
            if (File.Exists(defaultPath))
            {
                LoadDataFromJson(defaultPath);
            }
            else
            {
                MessageBox.Show("No saved data found. Please save data first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsValidDate(string dateString, out DateTime result)
        {
            // Trim the string to remove any leading or trailing whitespace
            dateString = dateString?.Trim()!;

            bool success = DateTime.TryParseExact(dateString, "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None, out result);

            if (!success)
            {
                result = DateTime.Now.Date;
                return false;
            }

            return true;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (isHandlingDataError) return;
            isHandlingDataError = true;

            try
            {
                e.ThrowException = false;  // stop showing error message
                e.Cancel = true;  // mark error as handled

                if (e.ColumnIndex >= 0 && e.ColumnIndex < DataGridView1.Columns.Count &&
                    e.RowIndex >= 0)
                {
                    if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnPoints")
                    {
                        DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].PointsColumnValue = 0;
                        }

                        this.BeginInvoke(new Action(() => {
                            DataGridView1.Refresh();
                        }));
                    }
                    else if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnDate")
                    {
                        if (e.RowIndex < dataList.Count)
                        {
                            dataList[e.RowIndex].DateColumnValue = DateTime.Now.Date;
                            this.BeginInvoke(new Action(() => {
                                DataGridView1.Refresh();
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataGridView1_DataError: {ex.Message}");
            }
            finally
            {
                isHandlingDataError = false;
            }
        }

        // Method for parsing cell values
        private void RefreshDataGridView()
        {
            try
            {
                // Disable and again connect DataSource UI during refresh
                DataGridView1.DataSource = null;
                bindingSource.DataSource = dataList;
                DataGridView1.DataSource = bindingSource;

                // reset mapping the columns
                ColumnDate.DataPropertyName = "DateColumnValue";
                ColumnDate.DefaultCellStyle.Format = "dd.MM.yyyy";
                ColumnProcedure.DataPropertyName = "ProcedureColumnValue";
                ColumnPoints.DataPropertyName = "PointsColumnValue";
                ColumnDelegate.DataPropertyName = "DelegateColumnValue";

                bindingSource.ResetBindings(false);
                DataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing DataGridView: {ex.Message}");
                MessageBox.Show($"Error refreshing DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Reset and restart timer on each text change
            updateTimer.Stop();
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();   // Stop timer
            LabelsToDataGridView(null!, EventArgs.Empty); // Now update data
        }

        private void TextBoxPoints_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI) return;
            isUpdatingUI = true;

            try
            {
                updateTimer.Stop();

                if (string.IsNullOrWhiteSpace(TextBoxPoints.Text))
                {
                    TextBoxPoints.Text = "0";
                    TextBoxPoints.SelectionStart = 1; // cursor after number
                    updateTimer.Start();
                    return;
                }

                string cleanedText = string.Empty;
                foreach (char c in TextBoxPoints.Text)
                {
                    if (char.IsDigit(c))
                    {
                        cleanedText += c;
                    }
                }

                if (string.IsNullOrEmpty(cleanedText))
                {
                    TextBoxPoints.Text = "0";
                    TextBoxPoints.SelectionStart = 1;
                }

                else if (cleanedText != TextBoxPoints.Text)
                {
                    int cursorPosition = TextBoxPoints.SelectionStart;
                    TextBoxPoints.Text = cleanedText;

                    if (cursorPosition <= TextBoxPoints.Text.Length)
                    {
                        TextBoxPoints.SelectionStart = cursorPosition;
                    }
                    else
                    {
                        TextBoxPoints.SelectionStart = TextBoxPoints.Text.Length;
                    }
                }
                updateTimer.Start();  //  starts timer for update data 
            }
            finally
            {
                isUpdatingUI = false;
            }
        }

        private void TextBoxPoints_TextChanged_New(object sender, EventArgs e)
        {
            if (isUpdatingUI) return;   //  recursive call prevention
            isUpdatingUI = true;

            try
            {
                updateTimer.Stop();  // stop timer for update

                int cursorPosition = TextBoxPoints.SelectionStart;  // remember cursor position

                if (string.IsNullOrWhiteSpace(TextBoxPoints.Text))  // control empty input 
                {
                    TextBoxPoints.Text = "0";
                    TextBoxPoints.SelectionStart = 1; // cursor after number
                }
                else
                {
                    // remove all not digit characters (numbers)
                    string cleanedText = string.Empty;
                    foreach (char c in TextBoxPoints.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            cleanedText += c;
                        }
                    }

                    if (string.IsNullOrEmpty(cleanedText))  // if is value empty - set on 0
                    {
                        TextBoxPoints.Text = "0";
                        TextBoxPoints.SelectionStart = 1;
                    }
                    // if changed, update text
                    else if (cleanedText != TextBoxPoints.Text)
                    {
                        TextBoxPoints.Text = cleanedText;

                        // set position of cursor
                        if (cursorPosition <= TextBoxPoints.Text.Length)
                        {
                            TextBoxPoints.SelectionStart = cursorPosition;
                        }
                        else
                        {
                            TextBoxPoints.SelectionStart = TextBoxPoints.Text.Length;
                        }
                    }
                }
                updateTimer.Start();  // refresh DataGridView with delay
            }
            finally
            {
                isUpdatingUI = false;
            }
        }


        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnPoints" ||
                DataGridView1.Columns[e.ColumnIndex].Name == "ColumnDate")
            {
                // allow all values ​​to pass validation - process empty values ​​in CellParsing and CellEndEdit
                e.Cancel = false;
                return;
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // recursive call prevention
            if (isHandlingDataError) return;
            isHandlingDataError = true;

            try
            {
                // Skontrolujeme, ktorý stĺpec sa upravuje
                if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnPoints")
                {
                    //  PointsColumnValue
                    var cellValue = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    bool setToZero = false;
                    int numericValue = 0;

                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        setToZero = true;
                    }
                    else if (!int.TryParse(cellValue.ToString(), out numericValue))
                    {
                        setToZero = true;  // if is not number, set to 0
                    }

                    if (setToZero)
                    {
                        // set cells to 0
                        DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

                        // if is row binded to dataList, refresh source data 
                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].PointsColumnValue = 0;
                        }
                    }
                    else
                    {
                        // if is value valid number, update model
                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].PointsColumnValue = numericValue;
                        }
                    }
                }
                else if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnDate")
                {
                    var cellValue = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    bool isValidDate = false;
                    DateTime dateColumnValue = DateTime.Now.Date; // default value if parsing fails is today's date

                    if (cellValue != null)
                    {
                        // try value converting to the date
                        isValidDate = DateTime.TryParseExact(
                            cellValue.ToString(),
                            "dd.MM.yyyy",
                            null,
                            System.Globalization.DateTimeStyles.None,
                            out dateColumnValue);
                    }

                    if (!isValidDate)
                    {
                        dateColumnValue = DateTime.Now.Date;
                        DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dateColumnValue;

                        // refresh binding source if row is in dataList
                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].DateColumnValue = dateColumnValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DataGridView1_CellEndEdit: {ex.Message}");

                try
                {
                    if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnPoints")
                    {
                        DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0; // for points set to 0
                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].PointsColumnValue = 0;
                        }
                    }
                    else if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnDate")
                    {
                        DateTime today = DateTime.Now.Date;
                        DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = today;

                        if (e.RowIndex < dataList.Count && !DataGridView1.Rows[e.RowIndex].IsNewRow)
                        {
                            dataList[e.RowIndex].DateColumnValue = today;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine($"Error setting default value: {ex.Message}");
                }
            }
            finally
            {
                isHandlingDataError = false;
            }
        }

        private void DataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnPoints")
            {
                try
                {
                    if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                    {
                        e.Value = 0;
                        e.ParsingApplied = true; // Označíme, že sme hodnotu spracovali
                        return;
                    }

                    // if value is not null or empty, try to parse it
                    if (!int.TryParse(e.Value.ToString(), out int result))
                    {
                        e.Value = 0;
                        e.ParsingApplied = true;
                    }
                }
                catch
                {
                    e.Value = 0;
                    e.ParsingApplied = true;
                }
            }

            else if (DataGridView1.Columns[e.ColumnIndex].Name == "ColumnDate")
            {
                try
                {
                    // if is value null or empty replace with today's date
                    if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                    {
                        e.Value = DateTime.Now.Date;
                        e.ParsingApplied = true;
                        return;
                    }

                    // converting value to DateTime
                    if (!DateTime.TryParseExact(
                        e.Value.ToString(),
                        "dd.MM.yyyy",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out DateTime dateValue))
                    {
                        // if conversion fails, set to today's date
                        e.Value = DateTime.Now.Date;
                        e.ParsingApplied = true;
                    }
                }
                catch
                {
                    e.Value = DateTime.Now.Date;
                    e.ParsingApplied = true;
                }
            }
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);

            // Again calculate DPI and use it for UI adjustments (if needed scaling factor) 
            ConfigureUIForHighDpi();
        }
    }
}
