<template>
  <v-card>
    <v-tabs vertical>
      <v-tab>
        <v-icon left>
          mdi-book-cog
        </v-icon>
      </v-tab>
      <v-tab>
        <v-icon left>
          mdi-lead-pencil
        </v-icon>
      </v-tab>
      <v-tab>
        <v-icon left>
          mdi-calculator-variant
        </v-icon>
      </v-tab>

      <v-tab-item>
        <AnnotationSchema/> 
      </v-tab-item>
      <v-tab-item>
        Annotation
      </v-tab-item>
      <v-tab-item>
        Auswertung      
      </v-tab-item>
    </v-tabs>
    </v-card>
</template>

<script>
import AnnotationSchema from './DetailViews/AnnotationSchema.vue'


export default {
  components: {
    AnnotationSchema,
  }
}
</script>
