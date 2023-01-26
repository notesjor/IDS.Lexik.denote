<template>
  <span class="token">
    <span class="lbl" v-for="v in token.values" :key="v">
      <div v-if="v.layer.type == 'ORIGINAL'" style="font-size:0.8em; margin:0 20px 0 20px">{{ v.value }}</div>
      <div v-else-if="v.layer.type == 'text'">
        <v-text-field v-model="v.value" variant="outlined" style="margin-bottom:5px"></v-text-field>
      </div>
      <div v-else-if="v.layer.type == 'tags'">
        <!--<v-autocomplete v-model="v.value" :items="v.layer.values" tabindex="-1" dense
          style="margin-bottom:5px"></v-autocomplete>-->
          <Tag :items="v.layer.values" tabindex="-1" :value="v.value"></Tag>
      </div>
    </span>
    <!--
    {{ this.data.s }} / {{ this.data.w }}
  -->
    <!--
    <div class="lbl">{{ this.info }}</div>
    <div class="txt">{{ this.text }}</div>
    <div class="lbl">{{ this.info }}</div>
  -->
  </span>
</template>

<script>
export default {
  props: {
    token: {
      type: Object,
      required: true,
    },
  },

};
</script>

<style lang="scss">
.token {
  display: inline-block;
  margin-bottom: 25px;
  margin-right: 5px;
  border-bottom: dashed lightgray 1px;
}

.txt {
  display: inline-block;
  position: relative;
  margin: 2px 5px 0 5px;
}

.lbl {
  display: block;
  position: relative;
  margin: -15 0 0 0;
  text-align: center;
}

input.v-field__input {
  padding: 0px;
  max-height: 35px;
  text-align: center;
}

label {
  visibility: collapse;
}

div.v-field__details {
  visibility: collapse;
}

div.v-input__details {
  visibility: collapse;
  display: none;
}

div.v-input__control {
  background-color: white;
}
</style>
