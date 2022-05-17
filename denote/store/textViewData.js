export const state = () => ({
  data: {
    text: "Hello world, this is a test",
    highlight: ["test", "world"]
  }
});
export const mutations = {
  select_meta_diathesis(state, data) {
    state.selected.meta_diathesis = data;
    state.results = search(state.selected, state.data);
  },
};
