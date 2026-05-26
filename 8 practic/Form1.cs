using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhysicsSolver;

public partial class Form1 : Form
{
    private TextBox ResultBox;

    public Form1()
    {
        InitializeComponent();
        SetupUI();
    }

   private void SetupUI()
{
    this.Text = "Решение физических задач";
    this.Size = new Size(550, 450); // Немного увеличим запас по умолчанию
    this.MinimumSize = new Size(500, 400);

    // Главный контейнер, который складывает элементы сверху вниз
    var mainPanel = new FlowLayoutPanel
    {
        Dock = DockStyle.Fill,
        FlowDirection = FlowDirection.TopDown,
        WrapContents = false,
        Padding = new Padding(20)
    };

    // Заголовок
    var title = new Label
    {
        Text = "Выберите физическую задачу:",
        AutoSize = true, // Важно! Элемент сам подстроится под размер шрифта
        Font = new Font("Segoe UI", 12, FontStyle.Bold),
        Margin = new Padding(0, 0, 0, 15)
    };

    // Панель для кнопок, чтобы они стояли в один ряд
    var buttonPanel = new FlowLayoutPanel
    {
        FlowDirection = FlowDirection.LeftToRight,
        AutoSize = true,
        Margin = new Padding(0, 0, 0, 20)
    };

    var btnTask12 = new Button
    {
        Text = "Архимедова сила (кубик)",
        Size = new Size(220, 40),
        Margin = new Padding(0, 0, 10, 0)
    };
    btnTask12.Click += BtnTask12_Click;

    var btnTask13 = new Button
    {
        Text = "Плотность жидкости",
        Size = new Size(220, 40)
    };
    btnTask13.Click += BtnTask13_Click;

    buttonPanel.Controls.Add(btnTask12);
    buttonPanel.Controls.Add(btnTask13);

    // Заголовок результата
    var resultLabel = new Label
    {
        Text = "Результат:",
        AutoSize = true,
        Font = new Font("Segoe UI", 10, FontStyle.Bold),
        Margin = new Padding(0, 0, 0, 5)
    };

    // Поле вывода
    this.ResultBox = new TextBox
    {
        Size = new Size(450, 150),
        Multiline = true,
        ReadOnly = true,
        BackColor = Color.WhiteSmoke,
        ScrollBars = ScrollBars.Vertical,
        Font = new Font("Segoe UI", 10) // Явно зададим шрифт для текста
    };

    // Собираем все в главный контейнер
    mainPanel.Controls.Add(title);
    mainPanel.Controls.Add(buttonPanel);
    mainPanel.Controls.Add(resultLabel);
    mainPanel.Controls.Add(ResultBox);

    // Добавляем контейнер на форму
    this.Controls.Add(mainPanel);
}

    // Задача 12: Архимедова сила для алюминиевого кубика
    private void BtnTask12_Click(object? sender, EventArgs e)
    {
        // Дано:
        double sideCm = 2.0;        // см
        double rhoWater = 1000.0;   // кг/м³
        double g = 9.81;            // м/с²

        // Перевод в СИ
        double sideM = sideCm / 100.0;
        double volume = Math.Pow(sideM, 3); // м³

        // Архимедова сила
        double archimedesForce = rhoWater * volume * g;

ResultBox.Text = 
    $"Задача 12: Архимедова сила (алюминиевый кубик 2 см в воде){Environment.NewLine}{Environment.NewLine}" +
    $"Объём кубика: {volume:F6} м³{Environment.NewLine}" +
    $"Выталкивающая сила: {archimedesForce:F2} Н";
    }

    // Задача 13: Плотность жидкости по давлению и высоте
    private void BtnTask13_Click(object? sender, EventArgs e)
    {
        // Дано:
        double pressurePa = 2000.0; // Па
        double heightM = 0.25;      // м (25 см)
        double g = 9.81;            // м/с²

        // Плотность = давление / (g * h)
        double density = pressurePa / (g * heightM);

ResultBox.Text =
    $"Задача 13: Плотность жидкости{Environment.NewLine}{Environment.NewLine}" +
    $"Давление: {pressurePa} Па{Environment.NewLine}" +
    $"Высота столба: {heightM} м{Environment.NewLine}" +
    $"Плотность жидкости: {density:F1} кг/м³";
    }
}