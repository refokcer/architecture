async function calculateOnServer(payload) {
    const response = await fetch('/api/calculator/calculate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    });

    if (!response.ok) {
        throw new Error(await response.text());
    }

    return response.json();
}
