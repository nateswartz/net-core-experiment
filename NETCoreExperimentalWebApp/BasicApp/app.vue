<template>
    <div class="ui grid">
        <news-articles></news-articles>
        <crypto-ticker></crypto-ticker>
    </div>
</template>

<script>
    import newsArticles from './Components/newsArticles'
    import cryptoTicker from './Components/cryptoTicker'

  export default {
    components: {
        newsArticles,
        cryptoTicker
    }
  }
</script>

<style>
</style>