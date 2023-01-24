<template>
  <div>
    <v-row justify="center" align="center">
      <v-col><TextView /></v-col>
    </v-row>
    <v-row>
      <v-col cols="4"> <CardView/> </v-col>
      <v-col cols="8"> <DetailView/> </v-col>
    </v-row>
  </div>
</template>

<script>
import TextView from "~/components/TextView.vue";
import CardView from "~/components/CardView.vue";
import DetailView from "../components/DetailView.vue";
export default {
  name: "IndexPage",
  components: { TextView, CardView, DetailView },
};
</script>
