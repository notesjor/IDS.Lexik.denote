<template>
    <div>{{ documentId }}</div>
    <br /><br />
    <strong>{{ layerInfoEditor }}</strong>
    <br /><br />
    <p>{{ layerInfo }}</p>
    <br /><br />
    <i>{{ document }}</i>
</template>

<script>
function getLayers(self) {
    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    fetch("https://www.owid.de/api/denote/layer", requestOptions)
        .then(response => response.json())
        .then(result => self.$data.layers = result)
        .then(() => {
            for (var key in self.$data.layers) {
                getLayer(self, key);
            }
        })
        .then(() => {
            prepareLayers(self);
        })
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
    var res = {};
    console.log(self.$data.layers);
    console.log(self.$data.layers["97ae87a647724f1e8ea7856da2622e64"]);
    for (var key in self.$data.layers) {
        var layer = { name: self.$data.layers[key] };

        var type = self.$data.layerInfo[key].$type;
        
        // simplyfy typename
        type = type.replace("IDS.Lexik.denote.Sdk.Model.Layer.Layer", "");
        type = type.replace(", IDS.Lexik.denote.Sdk", "");
        layer["$type"] = type;

        switch (type) {
            case "FreeText":
                break;   
            case "Tags":
                layer["$values"] = self.$data.layerInfo[key].$values;
                break;
            case "Original":
                break;     
            default:
                break;        
        }
console.log(key);
console.log(layer);
console.log(res);
        res[key] = layer;
    }

    self.$data.layerInfoEditor = res;
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
            layers: [],
            layerInfo: {},
            layerInfoEditor: {},
            document: {},
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