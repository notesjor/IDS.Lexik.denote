<template>
  <span class="token" :style="cssVars">
    {{ this.text }}
  </span>
</template>

<script>
export default {
  data() {
    return {
      color: "000",
    };
  },
  props: ["text", "highlight"],
  computed: {
    cssVars() {
      if (this.highlight)
        return {
          "--token-color":
            this.text in this.$store.state.textViewData.data.highlight
              ? this.$store.state.textViewData.data.highlight[this.text]
              : "#000",
        };
      else
        return {
          "--token-color": "#000",
        };
    },
  },
};
</script>

<style lang="scss">
.token {
  color: var(--token-color);
}
</style>
