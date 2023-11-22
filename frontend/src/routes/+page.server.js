/** @type {import('./$types').PageServerLoad} */
export const load = async () => {
	const response = await fetch('http://localhost:5230/computers');
    const items = await response.json();
	return {
		status: 200,
		pcs: items,
	};
};
