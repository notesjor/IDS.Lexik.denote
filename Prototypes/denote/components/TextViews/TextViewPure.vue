<template>
  <p>
    <Token v-for="(x,i) in tokens" :key="i" :text="x"/>
  </p>
</template>

<script>
import Token from './Token.vue'

export default {
  components: {
    Token,
  },
  data () {
    return {
      tokens: [],
    }
  },
  methods: {
    updateTokens () {
      this.tokens = this.$store.state.textViewData.data.tokens
    },
  },
  created () {
    this.$store.commit("textViewData/text_set", "Dies ist ein einfacher, verschachtelter; Test.")

    this.updateTokens()
  },
  watch: {
    textViewData: {
      handler: 'updateTokens',
      deep: true,
    },
  },
}
</script>
