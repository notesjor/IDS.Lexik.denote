<template>
  <p>
    {{ this.$store.state.textViewData.data.text }}
  </p>
</template>

<script>
export default {
  data () {
    return {
      text: '',
    }
  },
  computed: {
    textViewData () {
      return this.$store.state.textViewData
    },
  },
  methods: {
    updateText () {
      this.text = this.textViewData.text
    },
  },
  created () {
    this.updateText()
  },
  watch: {
    textViewData: {
      handler: 'updateText',
      deep: true,
    },
  },
}
</script>
