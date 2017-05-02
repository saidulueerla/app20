
using System;

using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

class GUI : Form
{
    Button start = new Button(); // Main Thread
    Button stop = new Button(); // Main Thread
    Label output = new Label(); // Main Thread

    public GUI() // Main Thread
    {
        this.Controls.Add(start); // Main Thread
        this.Controls.Add(stop); // Main Thread
        this.Controls.Add(output); // Main Thread

        start.Location = new Point(10, 10); // Main Thread
        stop.Location = new Point(150, 10); // Main Thread
        output.Location = new Point(100, 50); // Main Thread

        start.Text = "Start"; // Main Thread
        stop.Text = "Stop"; // Main Thread
        output.Text = "0"; // Main Thread

        start.Click += StartClicked; // Main Thread
        stop.Click += StopClicked; // Main Thread

        stop.Enabled = false; // disable the stop button
    }

    bool flag;

    // when called, called by the Main Thread
    void StartClicked(object sender, EventArgs e)
    {
        Task t = new Task(F1);
        t.Start(); // creates New Thread and calls F1 in the New Thread

        stop.Enabled = true; // enable the stop button
        start.Enabled = false; // disable the start button

    }


    void F1() // New Thread created by Task.Run
    {
        flag = true; // New Thread created by Task.Run
        int count = 0; // New Thead created by Task.Run
        while (flag) // New Thead created by Task.Run
        {
            count++; // New Thead created by Task.Run
            output.Text = count.ToString(); // New Thead created by Task.Run
        }
    } // New Thread Exits the function and Stops


    // when called, called by the Main Thread
    void StopClicked(object sender, EventArgs e)
    {
        flag = false; // Main Thread

        start.Enabled = true; // enable the start button
        stop.Enabled = false; // disable the stop button

    }
}

class App20
{
    static void Main() // Main Thread
    {
        GUI gui = new GUI(); // Main Thread
        gui.ShowDialog(); // Main Thread
    }
}