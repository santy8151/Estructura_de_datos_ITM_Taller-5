using System;
using System.Drawing;
using System.Windows.Forms;
using Backend;

namespace Frontend.Windows;

public partial class Form1 : Form
{
    private readonly DoublyLinkedList<string> _list = new(NaturalStringComparer.Default);

    public Form1()
    {
        InitializeComponent();
        SetupCustomUI();
    }

    private void SetupCustomUI()
    {
        this.Text = "Taller #5 - Listas Ligadas | ITM";
        this.Size = new Size(950, 680);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Font = new Font("Segoe UI", 9.5f);
        this.BackColor = Color.FromArgb(245, 247, 250);

        RefreshListView();
    }

    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        string val = txtInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(val))
        {
            MessageBox.Show("Por favor ingrese un elemento.", "Entrada vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _list.Add(val);
        txtInput.Clear();
        txtInput.Focus();
        Log($"Adicionado elemento '{val}'.");
        RefreshListView();
    }

    private void BtnShowForward_Click(object? sender, EventArgs e)
    {
        if (_list.IsEmpty)
        {
            Log("La lista está vacía.");
            return;
        }
        var forward = _list.ToForwardList();
        Log($"Recorrido hacia adelante:\n{string.Join(" -> ", forward)}");
    }

    private void BtnShowBackward_Click(object? sender, EventArgs e)
    {
        if (_list.IsEmpty)
        {
            Log("La lista está vacía.");
            return;
        }
        var backward = _list.ToBackwardList();
        Log($"Recorrido hacia atrás:\n{string.Join(" <- ", backward)}");
    }

    private void BtnSortDescending_Click(object? sender, EventArgs e)
    {
        if (_list.IsEmpty)
        {
            Log("La lista está vacía.");
            return;
        }
        _list.SortDescending();
        Log("La lista fue ordenada descendentemente (enlaces invertidos).");
        RefreshListView();
    }

    private void BtnShowModes_Click(object? sender, EventArgs e)
    {
        if (_list.IsEmpty)
        {
            Log("La lista está vacía. No hay moda.");
            return;
        }
        var (modes, maxFreq) = _list.GetModes();
        if (modes.Count == 1)
        {
            Log($"Moda única encontrada: '{modes[0]}' con {maxFreq} ocurrencia(s).");
        }
        else
        {
            Log($"Modas múltiples encontradas: {string.Join(", ", modes)} con {maxFreq} ocurrencia(s) c/u.");
        }
    }

    private void BtnShowChart_Click(object? sender, EventArgs e)
    {
        if (_list.IsEmpty)
        {
            Log("La lista está vacía. No hay gráfico para mostrar.");
            return;
        }
        string chart = _list.GetAsteriskChart();
        Log($"Gráfico de ocurrencias:\n{chart}");
    }

    private void BtnExists_Click(object? sender, EventArgs e)
    {
        string val = txtInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(val))
        {
            MessageBox.Show("Ingrese un elemento en el campo de texto para verificar su existencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_list.Exists(val))
        {
            Log($"El elemento '{val}' existe en la lista.");
        }
        else
        {
            Log($"No existe el elemento '{val}' en la lista.");
        }
    }

    private void BtnRemoveOne_Click(object? sender, EventArgs e)
    {
        string val = txtInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(val))
        {
            MessageBox.Show("Ingrese un elemento para eliminar una ocurrencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        bool removed = _list.RemoveOne(val);
        if (removed)
        {
            Log($"Se eliminó la primera ocurrencia de '{val}'.");
            RefreshListView();
        }
        else
        {
            Log($"El elemento '{val}' no existe en la lista.");
        }
    }

    private void BtnRemoveAll_Click(object? sender, EventArgs e)
    {
        string val = txtInput.Text.Trim();
        if (string.IsNullOrWhiteSpace(val))
        {
            MessageBox.Show("Ingrese un elemento para eliminar todas sus ocurrencias.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int count = _list.RemoveAll(val);
        if (count > 0)
        {
            Log($"Se eliminaron {count} ocurrencia(s) de '{val}'.");
            RefreshListView();
        }
        else
        {
            Log($"El elemento '{val}' no existe en la lista.");
        }
    }

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        _list.Clear();
        Log("Lista limpiada.");
        RefreshListView();
    }

    private void BtnPresetColors_Click(object? sender, EventArgs e)
    {
        _list.Clear();
        foreach (var c in new[] { "Blanco", "Azul", "Amarillo", "Verde", "Negro" })
        {
            _list.Add(c);
        }
        Log("Cargado preset de colores del enunciado (orden ascendente automático).");
        RefreshListView();
    }

    private void BtnPresetNumbers_Click(object? sender, EventArgs e)
    {
        _list.Clear();
        foreach (var n in new[] { "1", "2", "3", "3", "2", "5", "6", "6", "6", "3", "6" })
        {
            _list.Add(n);
        }
        Log("Cargado preset de números del enunciado (moda 6 con 4 ocurrencias).");
        RefreshListView();
    }

    private void RefreshListView()
    {
        dgvNodes.Rows.Clear();
        lblStatus.Text = $"Total elementos: {_list.Count} | Orden: {(_list.IsDescending ? "Descendente" : "Ascendente")}";

        var current = _list.Head;
        int idx = 0;
        while (current != null)
        {
            string prevStr = current.Previous?.Value ?? "(null)";
            string nextStr = current.Next?.Value ?? "(null)";
            string tag = "";
            if (current == _list.Head && current == _list.Tail) tag = "HEAD / TAIL";
            else if (current == _list.Head) tag = "HEAD";
            else if (current == _list.Tail) tag = "TAIL";

            dgvNodes.Rows.Add(idx, prevStr, current.Value, nextStr, tag);
            current = current.Next;
            idx++;
        }
    }

    private void Log(string message)
    {
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n\r\n");
        txtLog.SelectionStart = txtLog.Text.Length;
        txtLog.ScrollToCaret();
    }
}
