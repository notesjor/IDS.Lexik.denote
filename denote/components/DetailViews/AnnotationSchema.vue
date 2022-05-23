<template>
  <div style="padding: 0px 10px 5px 5px">
    <v-text-field
      label="Name"
      placeholder="Bitte eindeutigen Namen der Eigenschaft eintragen."
    ></v-text-field>
    <v-text-field
      label="Gruppe"
      placeholder="Durch die Angabe einer Gruppe, können Sie Eigenschaften individuell gruppieren."
    ></v-text-field>
    <v-text-field
      label="Kurzbeschreibung"
      placeholder="Die Kurzbeschreibung wird zu jeder Eigenschaft angezeigt (siehe links)."
    ></v-text-field>
    <v-combobox
      v-model="type_select"
      :items="type_items"
      label="Bezugspunkt"
      placeholder="Bitte wählen Sie aus, auf was sich die Eigenschaft bezieht."
    ></v-combobox>    
    <v-row>
      <v-col>
        <label
          class="v-label v-label--active theme--light"
          style="font-size: 18px"
          >Annotationsrichtlinie</label
        >
        <br />
        <label
          class="v-label v-label--active theme--light"
          style="font-size: 12px;"
          >Bitte geben Sie hier eine möglichst klare und detaillierte Richtlinie vor. Sie können Markdown zur Formatierung nutzen. Für Zweifelsfälle empfiehlt es sich, Beispiele aufzuführen. Sie können soviel schreiben wie Sie wollen.</label
        >
        <br />
        <Editor/>
        </v-col>
    </v-row>
    <Info/>
    <v-row>
      <v-col>
        <v-textarea
          name="input-7-1"
          label="Default style"
          value="The Woodman set to work at once, and so sharp was his axe that the tree was soon chopped nearly through."
          hint="Hint text"
        ></v-textarea>
      </v-col>
      <v-col>
        <label
          class="v-label v-label--active theme--light"
          style="font-size: 12px"
          >Farbe</label
        >
        <br />
        <v-color-picker
          dot-size="20"
          hide-canvas
          mode="rgba"
          show-swatches
          swatches-max-height="100"
        ></v-color-picker
      ></v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  data() {
    return {
      type_select: "Auf den gesamten Beleg (z. B. Metadatum)",
      type_items: [
        "Auf den gesamten Beleg (z. B. Metadatum)",
        "Stelle(n) im Beleg (z. B. Text-Annotation)",
        "Meta-Annotation einer Annotation (z. B. Struktur-Annotation)",
      ],
    };
  },
};
</script>
