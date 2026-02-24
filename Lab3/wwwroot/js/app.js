const form = document.getElementById('calculator-form');
const resultElement = document.getElementById('result');
const expressionElement = document.getElementById('expression');
const errorElement = document.getElementById('error');

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    errorElement.textContent = '';

    const payload = {
        leftOperand: Number(document.getElementById('leftOperand').value),
        rightOperand: Number(document.getElementById('rightOperand').value),
        operation: document.getElementById('operation').value
    };

    try {
        const response = await calculateOnServer(payload);
        resultElement.textContent = response.result;
        expressionElement.textContent = response.expression;
    } catch (error) {
        resultElement.textContent = '—';
        expressionElement.textContent = '';
        errorElement.textContent = error.message || 'Помилка під час обчислення.';
    }
});
