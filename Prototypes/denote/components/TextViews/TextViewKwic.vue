<template>
  <table style="widht:100%">
    <tr>
    <td style="text-align:right; width:auto">
      <span v-for="(x, i) in tokens" :key="i">
        <Token :text="x" :highlight="true" v-if="i < start" /> 
      </span>
    </td>
    <td style="text-align:center; width:auto; background-color:red">
      <span v-for="(x, i) in tokens" :key="i">
        <Token :text="x" :highlight="true" v-if="(i >= start) && (i <= stop)" /> 
      </span>
    </td>
    <td style="text-align:left; width:auto">
      <span v-for="(x, i) in tokens" :key="i">
        <Token :text="x" :highlight="true" v-if="i > start" /> 
      </span>
    </td>
    </tr>
  </table>
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
      start: 2,
      stop: 6,
    }
  },
  methods: {
    updateTokens () {
      this.tokens = this.$store.state.textViewData.data.tokens
    },
  },
  created () {
    this.$store.commit("textViewData/text_set", "Das ist ein Beispiel für Ivan.");

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
