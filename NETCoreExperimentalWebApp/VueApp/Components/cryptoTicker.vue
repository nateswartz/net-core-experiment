<template>
    <div class="four wide column" style="height:500px;">
        <div class="ui list" style="height:100%; overflow-y: scroll;">
            <div class="item" v-for="crypto in cryptocurrencies">
                <div class="content">
                    <div class="header" v-text="crypto.Name + ' (' + crypto.Symbol + ')'"></div>
                    <div class="description">
                        <span v-text="formatPrice(crypto.Price_USD)"></span>
                        <span v-text="' (' + crypto.percent_change_24h + '%)'" v-bind:style="{ color: crypto.percent_change_24h < 0 ? 'red' : 'green' }"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                cryptocurrencies: [],
            }
        },
        created: function () {
            var self = this;
            $.ajax({
                type: "GET",
                url: "/Home/GetCryptocurrencyValues",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    self.cryptocurrencies = data;
                }
            });
        },
        methods: {
            formatPrice: function(price) {
                if (price !== null) {
                    return price.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
                }
                return null;
            }
        }
    }

</script>
