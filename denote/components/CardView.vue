<template>
  <v-card max-width="450" class="mx-auto">
    <v-toolbar color="cyan" dark>
      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Schema</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
    </v-toolbar>
    <v-list three-line class="light">
      <template v-for="item in items">
        <v-subheader
          v-if="item.header"
          :key="item.header"
          v-text="item.header"
        ></v-subheader>
        <v-list-item v-else :key="item.title">
          <v-card style="margin-bottom: 10px">
            <div>
              <span style="float:left; display:block">
              <span
                :style="{
                  display: 'inline-block',
                  height: '50%',
                  'background-color':
                    item.color === undefined ? '#fff' : item.color,
                }"
                >&nbsp;</span
              >
              <span style="display: inline-block">
                <v-icon style="display: inline-block">{{ item.icon }}</v-icon>
              </span>
            </span>
            <span style="display: inline; font-weight: bold;">
              {{ item.title }}
            </span>
            </div>
            <div style="font-weight: 300; margin:10px">
              {{ item.subtitle }}
            </div>
          </v-card>
        </v-list-item>
      </template>
    </v-list>
  </v-card>
</template>

<style>
.v-list {
  height: 400px;
  overflow-y: auto;
}
</style>

<script>
export default {
  data: () => ({
    items: [
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Brunch this weekend?",
        subtitle: `<span class="text--primary">Ali Connors</span> &mdash; I'll be in your neighborhood doing errands this weekend. Do you want to hang out?`,
        color: "#f00",
      },
      {
        icon: "mdi-magnify",
        title: 'Summer BBQ <span class="grey--text text--lighten-1">4</span>',
        subtitle: `<span class="text--primary">to Alex, Scott, Jennifer</span> &mdash; Wish I could come, but I'm out of town this weekend.`,
      },
      {
        icon: "mdi-magnify",
        title: "Oui oui",
        subtitle:
          '<span class="text--primary">Sandra Adams</span> &mdash; Do you have Paris recommendations? Have you ever been?',
      },
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Birthday gift",
        subtitle:
          '<span class="text--primary">Trevor Hansen</span> &mdash; Have any ideas about what we should get Heidi for her birthday?',
      },
      {
        icon: "mdi-magnify",
        title: "Recipe to try",
        subtitle:
          '<span class="text--primary">Britta Holt</span> &mdash; We should eat this: Grate, Squash, Corn, and tomatillo Tacos.',
      },
      {
        icon: "mdi-magnify",
        title: "Oui oui",
        subtitle:
          '<span class="text--primary">Sandra Adams</span> &mdash; Do you have Paris recommendations? Have you ever been?',
      },
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Birthday gift",
        subtitle:
          '<span class="text--primary">Trevor Hansen</span> &mdash; Have any ideas about what we should get Heidi for her birthday?',
      },
      {
        icon: "mdi-magnify",
        title: "Recipe to try",
        subtitle:
          '<span class="text--primary">Britta Holt</span> &mdash; We should eat this: Grate, Squash, Corn, and tomatillo Tacos.',
      },
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Brunch this weekend?",
        subtitle: `<span class="text--primary">Ali Connors</span> &mdash; I'll be in your neighborhood doing errands this weekend. Do you want to hang out?`,
      },
      {
        icon: "mdi-magnify",
        title: 'Summer BBQ <span class="grey--text text--lighten-1">4</span>',
        subtitle: `<span class="text--primary">to Alex, Scott, Jennifer</span> &mdash; Wish I could come, but I'm out of town this weekend.`,
      },
      {
        icon: "mdi-magnify",
        title: "Oui oui",
        subtitle:
          '<span class="text--primary">Sandra Adams</span> &mdash; Do you have Paris recommendations? Have you ever been?',
      },
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Birthday gift",
        subtitle:
          '<span class="text--primary">Trevor Hansen</span> &mdash; Have any ideas about what we should get Heidi for her birthday?',
      },
      {
        icon: "mdi-magnify",
        title: "Recipe to try",
        subtitle:
          '<span class="text--primary">Britta Holt</span> &mdash; We should eat this: Grate, Squash, Corn, and tomatillo Tacos.',
      },
      {
        icon: "mdi-magnify",
        title: "Oui oui",
        subtitle:
          '<span class="text--primary">Sandra Adams</span> &mdash; Do you have Paris recommendations? Have you ever been?',
      },
      { header: "Today" },
      {
        icon: "mdi-magnify",
        title: "Birthday gift",
        subtitle:
          '<span class="text--primary">Trevor Hansen</span> &mdash; Have any ideas about what we should get Heidi for her birthday?',
      },
      {
        icon: "mdi-magnify",
        title: "Recipe to try",
        subtitle:
          '<span class="text--primary">Britta Holt</span> &mdash; We should eat this: Grate, Squash, Corn, and tomatillo Tacos.',
      },
    ],
  }),
};
</script>
