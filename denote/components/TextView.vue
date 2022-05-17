<template>
<v-card>
  <v-tabs vertical>
      <v-tab>
        <v-icon left>
          mdi-text-box-outline
        </v-icon>
      </v-tab>
      <v-tab>
        <v-icon left>
          mdi-message-bookmark
        </v-icon>
      </v-tab>
      <v-tab>
        <v-icon left>
          mdi-format-align-bottom
        </v-icon>
      </v-tab>

      <v-tab-item>
        <TextViewPure/>
      </v-tab-item>
      <v-tab-item>
        <TextViewHighlight/>
      </v-tab-item>
      <v-tab-item>
        <TextViewKwic/>        
        </v-tab-item>
    </v-tabs>
 </v-card> 
</template>
