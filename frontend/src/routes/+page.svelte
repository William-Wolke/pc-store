<script>
	export const status = 200;
	export let data;
	const pcs = data.pcs || [];
</script>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation</p>
<div>
	{#each pcs as item}
		<div>{item.name}</div>
	{/each}
</div>
