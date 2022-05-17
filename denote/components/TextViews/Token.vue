<template>
  <span class="token" :style="cssVars">
    <div class="txt">{{ this.text }}</div>
    <div class="lbl">{{ this.info }}</div>
  </span>
</template>

<script>
export default {
  data() {
    return {
      color: "000",
      info:"info"
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
  display:inline-block;
}
.txt{
  display: inline-block;
  position: relative;
  margin: 2px 5px 0 5px;
}
.lbl{
  display: block;
  position: relative;
  margin: -15 0 0 0;
  text-align: center;
  font-size: 0.6em;
}
</style>
