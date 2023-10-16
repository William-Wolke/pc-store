import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async () => {
	const response = await fetch('http://localhost:5230/computers');
    const items = await response.json();
	return {
		status: 200,
		data: items,
	};
};
