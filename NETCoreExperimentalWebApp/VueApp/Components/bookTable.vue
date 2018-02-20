<template>
    <div class="ui padded grid">
        <div class="row">
            <div class="column"><h2 class="ui header">List of Books</h2></div>
        </div>
        <div class="row">
            <div class="column">
                <table id="listItems" class="ui celled table">
                    <thead>
                        <tr>
                            <th>
                                Image
                            </th>
                            <th>
                                Title
                            </th>
                            <th>
                                Author
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="book in books">
                            <td>
                                <img class="ui tiny image" v-bind:src="book.Image" />
                            </td>
                            <td>{{ book.Title }}</td>
                            <td>{{ book.Author }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                books: [],
            }
        },
        created: function () {
            var self = this;
            $.ajax({
                type: "GET",
                url: "/Books/Get",
                success: function (data) {
                    self.books = data;
                }
            });
        },
    }

</script>
