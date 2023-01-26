<template>
  <div>
    <v-combobox label="Bitte Text auswählen..." :items="docs" item-title="value" v-model="docSelected" class="elevation-5" style="padding:5px"></v-combobox>
    <br/>
    <Editor :documentId="docSelected.key" class="elevation-5" style="padding:10px"></Editor>
  </div>
</template>

<script>
export default {
  data() {
    return {
      docs: [],
      docSelected: "",
   };
  },

  mounted() {
    var self = this;
    fetch('https://www.owid.de/api/denote/document')
      .then((response) => response.json())
      .then((data) => {
        self.docs = Object.keys(data).map((key) => {
          return {
            key: key,
            value: data[key],
          };
        });
      });
  },  
}
</script>

<style>

</style>