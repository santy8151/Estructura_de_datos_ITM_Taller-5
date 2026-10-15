namespace Frontend.Windows;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Label lblInput;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnPresetColors;
    private System.Windows.Forms.Button btnPresetNumbers;

    private System.Windows.Forms.Button btnShowForward;
    private System.Windows.Forms.Button btnShowBackward;
    private System.Windows.Forms.Button btnSortDescending;
    private System.Windows.Forms.Button btnShowModes;
    private System.Windows.Forms.Button btnShowChart;
    private System.Windows.Forms.Button btnExists;
    private System.Windows.Forms.Button btnRemoveOne;
    private System.Windows.Forms.Button btnRemoveAll;
    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.DataGridView dgvNodes;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.GroupBox grpOperations;
    private System.Windows.Forms.GroupBox grpInput;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        this.lblHeader = new System.Windows.Forms.Label();
        this.lblInput = new System.Windows.Forms.Label();
        this.txtInput = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnPresetColors = new System.Windows.Forms.Button();
        this.btnPresetNumbers = new System.Windows.Forms.Button();

        this.grpInput = new System.Windows.Forms.GroupBox();
        this.grpOperations = new System.Windows.Forms.GroupBox();

        this.btnShowForward = new System.Windows.Forms.Button();
        this.btnShowBackward = new System.Windows.Forms.Button();
        this.btnSortDescending = new System.Windows.Forms.Button();
        this.btnShowModes = new System.Windows.Forms.Button();
        this.btnShowChart = new System.Windows.Forms.Button();
        this.btnExists = new System.Windows.Forms.Button();
        this.btnRemoveOne = new System.Windows.Forms.Button();
        this.btnRemoveAll = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();

        this.dgvNodes = new System.Windows.Forms.DataGridView();
        this.txtLog = new System.Windows.Forms.TextBox();
        this.lblStatus = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).BeginInit();
        this.grpInput.SuspendLayout();
        this.grpOperations.SuspendLayout();
        this.SuspendLayout();

        // lblHeader
        this.lblHeader.AutoSize = true;
        this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(20, 50, 90);
        this.lblHeader.Location = new System.Drawing.Point(20, 15);
        this.lblHeader.Name = "lblHeader";
        this.lblHeader.Size = new System.Drawing.Size(430, 25);
        this.lblHeader.Text = "Taller #5 — Lista Doblemente Ligada (ITM)";

        // grpInput
        this.grpInput.Controls.Add(this.lblInput);
        this.grpInput.Controls.Add(this.txtInput);
        this.grpInput.Controls.Add(this.btnAdd);
        this.grpInput.Controls.Add(this.btnPresetColors);
        this.grpInput.Controls.Add(this.btnPresetNumbers);
        this.grpInput.Location = new System.Drawing.Point(20, 50);
        this.grpInput.Name = "grpInput";
        this.grpInput.Size = new System.Drawing.Size(900, 75);
        this.grpInput.Text = "Entrada de Datos";

        // lblInput
        this.lblInput.AutoSize = true;
        this.lblInput.Location = new System.Drawing.Point(15, 32);
        this.lblInput.Name = "lblInput";
        this.lblInput.Size = new System.Drawing.Size(65, 17);
        this.lblInput.Text = "Elemento:";

        // txtInput
        this.txtInput.Location = new System.Drawing.Point(85, 28);
        this.txtInput.Name = "txtInput";
        this.txtInput.Size = new System.Drawing.Size(200, 25);

        // btnAdd
        this.btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 120, 200);
        this.btnAdd.ForeColor = System.Drawing.Color.White;
        this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAdd.Location = new System.Drawing.Point(300, 26);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(130, 30);
        this.btnAdd.Text = "1. Adicionar";
        this.btnAdd.UseVisualStyleBackColor = false;
        this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

        // btnPresetColors
        this.btnPresetColors.Location = new System.Drawing.Point(520, 26);
        this.btnPresetColors.Name = "btnPresetColors";
        this.btnPresetColors.Size = new System.Drawing.Size(170, 30);
        this.btnPresetColors.Text = "Preset Colores PDF";
        this.btnPresetColors.Click += new System.EventHandler(this.BtnPresetColors_Click);

        // btnPresetNumbers
        this.btnPresetNumbers.Location = new System.Drawing.Point(705, 26);
        this.btnPresetNumbers.Name = "btnPresetNumbers";
        this.btnPresetNumbers.Size = new System.Drawing.Size(170, 30);
        this.btnPresetNumbers.Text = "Preset Números PDF";
        this.btnPresetNumbers.Click += new System.EventHandler(this.BtnPresetNumbers_Click);

        // grpOperations
        this.grpOperations.Controls.Add(this.btnShowForward);
        this.grpOperations.Controls.Add(this.btnShowBackward);
        this.grpOperations.Controls.Add(this.btnSortDescending);
        this.grpOperations.Controls.Add(this.btnShowModes);
        this.grpOperations.Controls.Add(this.btnShowChart);
        this.grpOperations.Controls.Add(this.btnExists);
        this.grpOperations.Controls.Add(this.btnRemoveOne);
        this.grpOperations.Controls.Add(this.btnRemoveAll);
        this.grpOperations.Controls.Add(this.btnClear);
        this.grpOperations.Location = new System.Drawing.Point(20, 135);
        this.grpOperations.Name = "grpOperations";
        this.grpOperations.Size = new System.Drawing.Size(900, 100);
        this.grpOperations.Text = "Operaciones del Menú";

        // Operations buttons row 1
        this.btnShowForward.Location = new System.Drawing.Point(15, 25);
        this.btnShowForward.Name = "btnShowForward";
        this.btnShowForward.Size = new System.Drawing.Size(160, 30);
        this.btnShowForward.Text = "2. Hacia adelante";
        this.btnShowForward.Click += new System.EventHandler(this.BtnShowForward_Click);

        this.btnShowBackward.Location = new System.Drawing.Point(185, 25);
        this.btnShowBackward.Name = "btnShowBackward";
        this.btnShowBackward.Size = new System.Drawing.Size(160, 30);
        this.btnShowBackward.Text = "3. Hacia atrás";
        this.btnShowBackward.Click += new System.EventHandler(this.BtnShowBackward_Click);

        this.btnSortDescending.Location = new System.Drawing.Point(355, 25);
        this.btnSortDescending.Name = "btnSortDescending";
        this.btnSortDescending.Size = new System.Drawing.Size(185, 30);
        this.btnSortDescending.Text = "4. Ordenar descendentemente";
        this.btnSortDescending.Click += new System.EventHandler(this.BtnSortDescending_Click);

        this.btnShowModes.Location = new System.Drawing.Point(550, 25);
        this.btnShowModes.Name = "btnShowModes";
        this.btnShowModes.Size = new System.Drawing.Size(160, 30);
        this.btnShowModes.Text = "5. Mostrar la(s) moda(s)";
        this.btnShowModes.Click += new System.EventHandler(this.BtnShowModes_Click);

        this.btnShowChart.Location = new System.Drawing.Point(720, 25);
        this.btnShowChart.Name = "btnShowChart";
        this.btnShowChart.Size = new System.Drawing.Size(160, 30);
        this.btnShowChart.Text = "6. Mostrar gráfico";
        this.btnShowChart.Click += new System.EventHandler(this.BtnShowChart_Click);

        // Operations buttons row 2
        this.btnExists.Location = new System.Drawing.Point(15, 62);
        this.btnExists.Name = "btnExists";
        this.btnExists.Size = new System.Drawing.Size(160, 30);
        this.btnExists.Text = "7. Existe";
        this.btnExists.Click += new System.EventHandler(this.BtnExists_Click);

        this.btnRemoveOne.Location = new System.Drawing.Point(185, 62);
        this.btnRemoveOne.Name = "btnRemoveOne";
        this.btnRemoveOne.Size = new System.Drawing.Size(180, 30);
        this.btnRemoveOne.Text = "8. Eliminar 1 ocurrencia";
        this.btnRemoveOne.Click += new System.EventHandler(this.BtnRemoveOne_Click);

        this.btnRemoveAll.Location = new System.Drawing.Point(375, 62);
        this.btnRemoveAll.Name = "btnRemoveAll";
        this.btnRemoveAll.Size = new System.Drawing.Size(180, 30);
        this.btnRemoveAll.Text = "9. Eliminar todas";
        this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);

        this.btnClear.BackColor = System.Drawing.Color.FromArgb(220, 70, 70);
        this.btnClear.ForeColor = System.Drawing.Color.White;
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.Location = new System.Drawing.Point(720, 62);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(160, 30);
        this.btnClear.Text = "Limpiar Lista";
        this.btnClear.UseVisualStyleBackColor = false;
        this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

        // lblStatus
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
        this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(40, 80, 140);
        this.lblStatus.Location = new System.Drawing.Point(20, 245);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(200, 17);
        this.lblStatus.Text = "Total elementos: 0 | Orden: Ascendente";

        // dgvNodes
        this.dgvNodes.AllowUserToAddRows = false;
        this.dgvNodes.AllowUserToDeleteRows = false;
        this.dgvNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvNodes.BackgroundColor = System.Drawing.Color.White;
        this.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvNodes.Columns.Add("colIdx", "Índice");
        this.dgvNodes.Columns.Add("colPrev", "Previous <-");
        this.dgvNodes.Columns.Add("colVal", "[ VALOR ]");
        this.dgvNodes.Columns.Add("colNext", "-> Next");
        this.dgvNodes.Columns.Add("colTag", "Apuntadores Extremos");
        this.dgvNodes.Location = new System.Drawing.Point(20, 270);
        this.dgvNodes.Name = "dgvNodes";
        this.dgvNodes.ReadOnly = true;
        this.dgvNodes.RowHeadersVisible = false;
        this.dgvNodes.Size = new System.Drawing.Size(460, 340);

        // txtLog
        this.txtLog.BackColor = System.Drawing.Color.FromArgb(20, 25, 35);
        this.txtLog.ForeColor = System.Drawing.Color.FromArgb(220, 240, 255);
        this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
        this.txtLog.Location = new System.Drawing.Point(495, 270);
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.ReadOnly = true;
        this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLog.Size = new System.Drawing.Size(425, 340);

        // Form1
        this.ClientSize = new System.Drawing.Size(940, 630);
        this.Controls.Add(this.lblHeader);
        this.Controls.Add(this.grpInput);
        this.Controls.Add(this.grpOperations);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.dgvNodes);
        this.Controls.Add(this.txtLog);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "Form1";

        ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).EndInit();
        this.grpInput.ResumeLayout(false);
        this.grpInput.PerformLayout();
        this.grpOperations.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
