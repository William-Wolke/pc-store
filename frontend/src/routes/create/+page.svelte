<form class="container" method="POST">
    <h1>Create a pc</h1>
    <label for="name">Name</label>
    <input type="text" placeholder="name" name="Name" id="name" />
    <label for="processor">Processor</label>
    <input type="text" placeholder="Processor" name="processor" id="processor">
    <label for="graphics">Graphics card</label>
    <input type="text" placeholder="Graphics Card" name="graphicsCard" id="graphics">
    <label for="description">Description</label>
    <textarea placeholder="Description" name="description" id="description"></textarea>
    <label for="image">Image link</label>
    <input type="text" placeholder="Image link" name="imageLink" id="image">
    <label for="price">Price</label>
    <input type="number" placeholder="5000" name="price" id="price">
    <button type="submit">Create</button>
</form>

<style>
    .pc-form {
        padding-top: 25px;
    }
</style>
