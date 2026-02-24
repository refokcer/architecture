using Lab3.Contracts;
using Lab3.Models;
using Lab3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CalculatorController(ICalculationService calculationService) : ControllerBase
{
    [HttpPost("calculate")]
    [ProducesResponseType(typeof(CalculationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public ActionResult<CalculationResponse> Calculate([FromBody] CalculationRequest request)
    {
        try
        {
            var result = calculationService.Calculate(request.LeftOperand, request.RightOperand, request.Operation);
            var expression = $"{request.LeftOperand} {GetOperationSymbol(request.Operation)} {request.RightOperand} = {result}";
            return Ok(new CalculationResponse(result, expression));
        }
        catch (DivideByZeroException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    private static string GetOperationSymbol(OperationType operation) => operation switch
    {
        OperationType.Add => "+",
        OperationType.Subtract => "−",
        OperationType.Multiply => "×",
        OperationType.Divide => "÷",
        _ => "?"
    };
}
