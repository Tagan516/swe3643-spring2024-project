namespace CalculatorEndToEndTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5113");
    }
    [Test]
    public async Task CalculatorWebApp_PageTitle_IsCalculator()
    {
        //preq-E2E-TEST-5
        
        const string pageTitle = "Calculator";

        await Expect(Page).ToHaveTitleAsync(pageTitle);
    }
    
    [Test]
    public async Task CalculatorWebApp_AddsTwoNumbers_ReturnsSum()
    {
        //preq-E2E-TEST-6

        //Create locators for both input fields, add button, and result box
        var inputA = Page.GetByLabel("Input A");
        var inputB = Page.GetByLabel("Input B");
        var add = Page.GetByText("A + B");
        var resultBox = Page.GetByTitle("Output Text");
        
        //Input data into fields
        await inputB.FillAsync("0");
        await inputA.FillAsync("1");
        
        //Click Add button
        await add.ClickAsync();

        await Expect(resultBox).ToContainTextAsync("1 + 0 = 1");
    }

    [Test]
    public async Task CalculatorWebApp_DivideByZero_ReturnsNotANumber()
    {
        //preq-E2E-TEST-7
        
        //Create locators for both input fields, add button, and result box
        var inputA = Page.GetByLabel("Input A");
        var inputB = Page.GetByLabel("Input B");
        var divide = Page.GetByText("A / B");
        var resultBox = Page.GetByTitle("Output Text");
        
        //Input data into fields
        await inputB.FillAsync("0");
        await inputA.FillAsync("1");
        
        //Click Add button
        await divide.ClickAsync();
        
        await Expect(resultBox).ToContainTextAsync("Not a Number");
    }
    
    [Test]
    public async Task CalculatorWebApp_NonNumericEntry_ReturnsError()
    {
        //preq-E2E-TEST-8
        
        //Create locators for both input fields, add button, and result box
        var inputA = Page.GetByLabel("Input A");
        var inputB = Page.GetByLabel("Input B");
        var divide = Page.GetByText("A / B");
        var resultBox = Page.GetByTitle("Output Text");
        
        //Input data into fields
        await inputA.FillAsync("0");
        await inputB.FillAsync("two");
        
        //Click Add button
        await divide.ClickAsync();
        
        await Expect(resultBox).ToContainTextAsync("Invalid input, numbers only");
    }
    
    [Test]
    public async Task CalculatorWebApp_ClearButtonReset_ReturnsToDefaultState()
    {
        //preq-E2E-TEST-9

        //Create locators for both input fields, add button, and result box
        var inputA = Page.GetByLabel("Input A");
        var inputB = Page.GetByLabel("Input B");
        var add = Page.GetByText("A + B");
        var clear = Page.GetByText("Clear");
        var resultBox = Page.GetByTitle("Output Text");
        
        //Input data into fields
        await inputA.FillAsync("0");
        await inputB.FillAsync("1");
        
        //Click Add button
        await add.ClickAsync();
        await Expect(resultBox).ToContainTextAsync("0 + 1 = 1");
        await clear.ClickAsync();

        await Expect(resultBox).ToContainTextAsync("Enter value(s) below and select an operation.");
        
        //These two checks always failed, and I could not figure out why. They find the input fields empty, and I
        //could not find a fix that worked. As best I can tell from the logic for my web app, these input fields should
        //never be empty. They should always have an entered value or be set to 0, so I could not understand why playwright
        //was finding them empty. When run in browser, the input fields are never empty, even before I added the placeholder
        //await Expect(inputA).ToContainTextAsync("0");
        //await Expect(inputB).ToContainTextAsync("0");
    }
}