<template>
    <div>
        <v-lazy v-for="t in documentTokens" :key="t.id" style="display:inline-block">
            <Token :token="t"></Token>
        </v-lazy>
    </div>
</template>

<script>
function getLayers(self) {
    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    fetch("https://www.owid.de/api/denote/layer", requestOptions)
        .then(response => response.json())
        .then(result => self.$data.layerNames = result)
        .then(() => {
            for (var id in self.$data.layerNames) {
                getLayer(self, id);
            }
        })
        .then(() => prepareLayers(self))
        .catch(error => console.log('error', error));
}

function getLayer(self, id) {
    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    fetch("https://www.owid.de/api/denote/layer?id=" + id, requestOptions)
        .then(response => response.json())
        .then(result => self.$data.layerInfo[id] = result)
        .catch(error => console.log('error', error));
}

function prepareLayers(self) {
    // TODO: Notfall
    self.layerInfo = {
        "97ae87a647724f1e8ea7856da2622e64": { "type": "ORIGINAL", "isReadOnly": true, "position": 0 },
        "97458e2c75e44ab0940c35302ffbf2a7": { "type": "text", "position": 1 },
        "5e751af3f3e74543848aa13d9edf28fc": { "type": "tags", "values": ['Name', 'Ort', 'Zahl', 'Zeitpunkt', 'Gruppe'], "position": 2 }
    };

    var res = [];
    for (var key in self.layerNames) {
        var layer = { name: self.layerNames[key] };

        var type = self.layerInfo[key].type;
        layer["type"] = type;
        layer["id"] = key;
        layer["position"] = self.layerInfo[key].position;

        switch (type) {
            case "text":
                break;
            case "tags":
                layer["values"] = self.$data.layerInfo[key].values;
                break;
            case "ORIGINAL":
                layer["isReadOnly"] = true;
                break;
            default:
                break;
        }

        res.push(layer);
    }

    self.$data.layerInfoEditor = res.sort((a, b) => a.position - b.position);     
    // create dictionary for res.key -> res index
    self.$data.layerInfoEditorResolve = self.$data.layerInfoEditor.reduce((obj, item, index) => {
        obj[item.id] = index;
        return obj;
    }, {});

    console.log(self.$data.layerInfoEditorResolve);
}

function getDocument(self, id) {
    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    fetch("https://www.owid.de/api/denote/document?id=" + id, requestOptions)
        .then(response => response.json())
        .then(result => self.$data.document = result)
        .then(() => prepareDocument(self))
        .catch(error => console.log('error', error));
}
function prepareDocument(self) {
    var layerKey = Object.keys(self.layerNames).find(key => self.layerNames[key] === "ORIGINAL");
    if (layerKey === undefined)
        layerKey = Object.keys(self.layerNames).find(key => self.layerNames[key] === "Wort");
    if (layerKey === undefined)
        layerKey = Object.keys(self.layerNames)[0];

    var lead = self.document[layerKey];
    if (lead === undefined)
        throw new Error("No document found for layer " + layerKey);

    var id = 0;
    var tokens = [];
    for (let s = 0; s < lead.length; s++)
        for (let w = 0; w < lead[s].length; w++) {
            var token = { id: id++, s: s, w: w, values: {} }
            for (let l in self.layerInfoEditor)
                {
                    var guid = self.layerInfoEditor[l].id;
                    token.values[guid] = { 
                        layer: self.layerInfoEditor[self.layerInfoEditorResolve[guid]], 
                        value: self.document[guid][s][w], 
                    }
                }
            tokens.push(token);
        }

    self.documentTokens = tokens;
    console.log(self.documentTokens);
}

export default {
    props: {
        documentId: {
            type: String,
            required: true,
        },
    },

    data() {
        return {
            layerNames: [], // layer id -> layer name
            layerInfo: {}, // layer id -> layer info
            layerInfoEditor: [], // layerInfo specialized for editor
            layerInfoEditorResolve: {}, // layer id -> layerInfoEditor index
            document: {}, // current document
            documentTokens: [], // current document tokens (for editor)
        };
    },

    mounted() {
        getLayers(this);
    },

    watch: {
        documentId: function (newVal) {
            getDocument(this, newVal);
        },
    },
}
</script>

<style>

</style>