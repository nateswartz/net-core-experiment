<template>
    <div class="twelve wide column">
        <div class="field">
            <label>Source</label>
            <select v-model="selectedSources" class="ui dropdown" name="dropdown" multiple>
                <option v-for="source in articleSources" v-bind:value="source.Id">
                    {{ source.Name }}
                </option>
            </select>
        </div>

        <div class="ui divider"></div>
        <div class="ui segment" v-show="selectedSources.length === 0">
            No sources selected, pick some from the dropdown.
        </div>
        <div class="ui link cards">
            <div class="ui card" v-for="article in articles">
                <a class="image" v-bind:href="article.Url" target="_blank">
                    <img v-bind:src="article.UrlToImage" />
                </a>
                <a class="content" v-bind:href="article.Url" target="_blank">
                    <div class="header">{{article.Title}}</div>
                    <div class="meta">{{article.Author}}</div>
                </a>
                <a class="extra content" v-bind:href="article.Url" target="_blank">
                    <div class="meta">{{article.Description}}</div>
                </a>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                articleSources: [],
                selectedSources: [],
                articles: []
            }
        },
        watch: {
            selectedSources: function (val) {
                console.log("Triggered Watch");
                var self = this;
                if (self.selectedSources.length !== 0) {
                    $.ajax({
                        type: "POST",
                        url: "/Home/GetArticles",
                        data: JSON.stringify(self.selectedSources),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            console.log("Articles");
                            console.log(data);
                            $('.dimmer').removeClass('active');
                            self.articles = data;
                        }
                    });
                }
                self.articles = [];
                console.log("Nothing");
            }
        },
        mounted: function () {
            var self = this;
            $.ajax({
                type: "Get",
                url: "/Home/GetSources",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log("Sources");
                    console.log(data);
                    self.articleSources = data;
                }
            });
        }
    }
</script>

<style>
</style>
