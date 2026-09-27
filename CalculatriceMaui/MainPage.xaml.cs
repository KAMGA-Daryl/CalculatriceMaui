namespace CalculatriceMaui;

public partial class MainPage : ContentPage
{
    private string _currentInput = "0";
    private double _firstNumber = 0;
    private string _operator = "";
    private bool _isNewEntry = true;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnNumberClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.CommandParameter.ToString();

        if (_currentInput == "0" || _isNewEntry)
        {
            _currentInput = pressed;
            _isNewEntry = false;
        }
        else
        {
            _currentInput += pressed;
        }

        lblResult.Text = _currentInput;
    }

    private void OnDecimalClicked(object sender, EventArgs e)
    {
        if (_isNewEntry)
        {
            _currentInput = "0.";
            _isNewEntry = false;
        }
        else if (!_currentInput.Contains("."))
        {
            _currentInput += ".";
        }

        lblResult.Text = _currentInput;
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (!string.IsNullOrEmpty(_operator) && !_isNewEntry)
        {
            OnEqualsClicked(sender, e);
        }

        if (double.TryParse(_currentInput, out double number))
        {
            _firstNumber = number;
        }

        _operator = button.CommandParameter.ToString();
        lblOperation.Text = $"{_firstNumber} {_operator}";
        _isNewEntry = true;
    }

    private void OnEqualsClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_operator)) return;

        if (double.TryParse(_currentInput, out double secondNumber))
        {
            double result = 0;

            switch (_operator)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "×":
                    result = _firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber == 0)
                    {
                        lblResult.Text = "Erreur";
                        lblOperation.Text = "Division par zéro impossible";
                        ResetCalculatorState();
                        return;
                    }
                    result = _firstNumber / secondNumber;
                    break;
            }

            lblOperation.Text = $"{_firstNumber} {_operator} {secondNumber} =";
            lblResult.Text = result.ToString();
            _currentInput = result.ToString();
            _operator = "";
            _isNewEntry = true;
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        ResetCalculatorState();
        lblResult.Text = "0";
        lblOperation.Text = "";
    }

    private void OnBackSpaceClicked(object sender, EventArgs e)
    {
        if (_currentInput.Length > 1 && !_isNewEntry)
        {
            _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
        }
        else
        {
            _currentInput = "0";
            _isNewEntry = true;
        }
        lblResult.Text = _currentInput;
    }

    private void OnSignChangedClicked(object sender, EventArgs e)
    {
        if (double.TryParse(_currentInput, out double number))
        {
            number = -number;
            _currentInput = number.ToString();
            lblResult.Text = _currentInput;
        }
    }

    private void OnPercentageClicked(object sender, EventArgs e)
    {
        if (double.TryParse(_currentInput, out double number))
        {
            number = number / 100;
            _currentInput = number.ToString();
            lblResult.Text = _currentInput;
        }
    }

    private void ResetCalculatorState()
    {
        _firstNumber = 0;
        _operator = "";
        _isNewEntry = true;
        _currentInput = "0";
    }
}