<template>
    <div style="margin-top:10px">
        <v-icon size="x-small" style="display:inline-block; margin:-30px 10px 0px 5px;"
            @click="dialog = true" color="#bbb">mdi-tag-text-outline</v-icon>
        <v-chip-group active-class="primary--text" style="display:inline-block" column>
            <v-chip v-for="item in value" :key="item" :value="item" small closable size="x-small"
                @click:close="value = value.filter(i => i !== item)">
                {{ item }}
            </v-chip>
        </v-chip-group>
        <v-dialog v-model="dialog" max-width="600">
            <v-card>
                <v-card-text>
                    <v-autocomplete v-model="newItem" :items="items" width="200"></v-autocomplete>
                </v-card-text>
                <v-card-actions>
                    <v-btn color="primary" block @click="addTag">Hinzufügen</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
export default {
    props: {
        items: {
            type: Array,
            required: true,
        },
    },
    data: () => ({
        dialog: false,
        newItem: null,
        value: []
    }),
    methods: {
        addTag() {
            this.value.push(this.newItem);
            this.newItem = null;
            this.dialog = false;
        }
    }
}
</script>
