
# Ask the user to input a number using the given prompt string
function Get-Double {

    param (
        $Prompt
    )

    do {
        $inp = Read-Host -Prompt $Prompt

        # Try to cast, if that fails $num will contain null
        $num = $inp -as [Double]
        $ok = $num -ne $NULL
        if (-not $ok) {
            Write-Host "You must enter a numeric value" -ForegroundColor Red
        }
    # try until the user gets it right
    } until ($ok)

    return $num
}

# Do a exponentiation using the given base and exponent
function Calculate-Exponent {

    param (
        $Base,
        $Exp
    )

    if ($exp -eq 0) {
        return 1
    }

    $res = $Base

    for ($i = $Exp; $i -gt 1; $i--) {
        $res *= $Base
    }

    return $res
}

# loop until the end of time
while (1) {
    Clear-Host # alias "clear" would work too
    Write-Host "PowerShell CLI calc v1.0" -ForegroundColor Yellow
    Write-Host "Choose a function"
    Write-Host "1 - Add        3 - Multiply   5 - Exponentiation"
    Write-Host "2 - Subtract   4 - Divide"

    do {
        # The Read-Host cmdlet puts a ":" after the supplied prompt when using -Prompt.
        # If we do it like this, we can get the required custom prompt without that
        Write-Host -nonewline ">>> "
        $mode = Read-Host

        #match a single 1 2 3 4 or 5
        $ok = $mode -match "^[1-5]$"

        if (-not $ok) {
            Write-Host "Please enter a number between 1 and 5" -ForegroundColor Red
        }
    } until ($ok)

    # Newline for formatting
    Write-Host ""

    # Array definitions so that we can use the inputted mode value easily
    $modes = @("Addition", "Subtraction", "Multiplication", "Division", "Exponentation")
    $signs = @("+", "-", "*", "/", "^")

    Write-Host $("You chose: {0}" -f $modes[$mode-1])
    Write-Host $("Please choose two numbers a and b to calculate a {0} b" -f $signs[$mode-1])
    Write-Host ""

    $a = Get-Double -Prompt "a"
    $b = Get-Double -Prompt "b"

    switch ($mode) {
        1 {$res = $a + $b; break}
        2 {$res = $a - $b; break}
        3 {$res = $a * $b; break}
        4 {$res = $a / $b; break}
        5 {$res = Calculate-Exponent -Base $a -Exp $b; break}
    }

    Write-Host $("Result: {0} {1} {2} = {3}" -f $a, $signs[$mode-1], $b, $res)
    # Newline for formatting
    Write-Host ""

    Write-Host "Type Q/q to quit or press Enter to restart"
    do {
        Write-Host -NoNewline ">>> "
        $inp = Read-Host

        # Match a single q or Q
        if ($inp -match "^[qQ]$") {
            exit;
        }

        # Pressing enter results in the input being of length 0
        $ok = $inp.Length -eq 0
        if (-not $ok) {
            Write-Host "Please type either Q/q to quit or press Enter to restart!" -ForegroundColor Red
        }
    } until ($ok)

}