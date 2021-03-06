const state = {
  leftDrawerOpen: {
    type: Boolean,
    default: true,
  },
};

const getters = {
  leftDrawerOpen: (state) => state.leftDrawerOpen,
};

const actions = {
  toggleLeftDrawerOpen({ commit }) {
    commit("setLeftDrawerOpen", !state.leftDrawerOpen);
  },
};

const mutations = {
  setLeftDrawerOpen: (state, open) => {
    state.leftDrawerOpen = open;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
