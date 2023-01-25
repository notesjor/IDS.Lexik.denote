<template>
  <div>
    <v-card outlined>
      <v-card-text>
        <v-combobox label="Bitte Text auswählen..." :items="docs" item-title="value" v-model="docSelected"></v-combobox>
        <br/>
        <Editor :documentId="docSelected.key"></Editor>
      </v-card-text>
    </v-card>
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