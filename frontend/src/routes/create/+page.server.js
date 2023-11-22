/** @type {import('./$types').Actions} */
export const actions = {
	default: async (event) => {
		try {
            const data = JSON.stringify(event.request.formData())
			const response = await fetch('http://localhost:5230/computer', {
				method: 'POST',
				body: data,
				headers: {
					'Content-Type': 'application/json'
				}
			});
			return {
				success: true
			};
		} catch (error) {
			console.error(error);
		}
	}
};
