async function calculateOnServer(payload) {
    const response = await fetch('/api/calculator/calculate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    });

    if (!response.ok) {
        const rawError = await response.text();
        let errorMessage = rawError || 'Помилка запиту до сервера.';

        try {
            const parsedError = JSON.parse(rawError);
            if (parsedError?.errors) {
                const firstFieldError = Object.values(parsedError.errors)
                    .flat()
                    .find(Boolean);

                if (firstFieldError) {
                    errorMessage = firstFieldError;
                }
            } else if (parsedError?.title) {
                errorMessage = parsedError.title;
            }
        } catch {
            // Ignore JSON parsing errors and keep raw error text.
        }

        throw new Error(errorMessage);
    }

    return response.json();
}
