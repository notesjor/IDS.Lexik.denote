export const state = () => ({
  data: {
    tokens: [],
    highlight: {"ist": "#f00", "Test": "#00f"},
  }
});

export const mutations = {
  text_set(state, text) {
    var replacements = ['.', '!', '?', ':', ';', ','];
    text = text.toString();
    for (var i = 0; i < replacements.length; i++) {
      text = text.replace(replacements[i], ` ${replacements[i]} `);
    }
    state.data.tokens = text.toString().split(" ");
  },
  token_set(state, token) {
    state.data.token = token;
  }, 
  highlight_set(state, highlight) {
    state.data.highlight = highlight;
  }
}
