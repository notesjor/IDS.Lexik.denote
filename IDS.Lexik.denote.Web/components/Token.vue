<template>
    <span class="token" :style="cssVars">
      <div class="lbl">{{ this.info }}</div>
      <div class="txt">{{ this.text }}</div>
      <div class="lbl">{{ this.info }}</div>
    </span>
  </template>
  
  <script>
  export default {
    props: {
        token: {
            type: Array,
            required: true,
        },
        info: {
            type: Object,
            required: true,
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
  