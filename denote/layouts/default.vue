<template>
  <v-app>
    <v-app-bar app dark class="d-print-none" style="z-index: 999">
      <div>
        <a href="https://www.owid.de/plus/" target="_blank">
          <img alt="Logo" height="40px" src="/logo/logo_left.svg" />
        </a>
      </div>

      <v-spacer></v-spacer>

      <div>
        <a href="https://www.ids-mannheim.de/" target="_blank">
          <img alt="Logo" height="70px" src="/logo/logo_right.svg" />
        </a>
      </div>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer padless dark>
      <v-card class="flex" flat tile>
        <v-card-text class="py-2" style="text-align: right">
          <div style="display: inline-block">
            {{ new Date().getFullYear() }} —
            <strong>denote</strong> — 
          </div>
          <div style="display: inline-block">
            <a href="mailto:ruediger@ids-mannheim.de" style="margin-left: 15px"
              >Kontakt</a
            >
            <a
              href="https://www.owid.de/wb/owid/impressum.html"
              style="margin-left: 15px"
              >Impressum</a
            >
            <a
              href="https://www.owid.de/wb/owid/privacy.html"
              style="margin-left: 15px"
              >Datenschutzhinweis</a
            >
          </div>
        </v-card-text>
      </v-card>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: "DefaultLayout",
  data() {
    return {
      title: "Leibniz-Institut für Deutsche Sprache - denote",
    };
  },
};
</script>
