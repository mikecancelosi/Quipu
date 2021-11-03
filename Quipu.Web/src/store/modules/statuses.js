import StatusTypeRepository from "./../../repositories/StatusTypeRepository";

const state = {
  statusTypes: [],
  statusDropdownOptions: [],
};

const getters = {
  allStatusTypes: (state) => state.statusTypes,
  allStatusDropdownOptions: (state) => state.statusDropdownOptions,
  getStatusByID: (state) => (id) => {
    return state.statusTypes.find((x) => x.id === id);
  },
};

const actions = {
  async fetchStatusTypes({ commit }) {
    const statuses = (await StatusTypeRepository.get()).data;
    const statusoptions = [];

    statuses.forEach((status) => {
      statusoptions.push({
        label: status.name,
        value: status,
        category: status.id,
      });
    });

    commit("setStatusTypes", statuses);
    commit("setStatusDropdownOptions", statusoptions);
  },
};

const mutations = {
  setStatusTypes: (state, statuses) => {
    state.statusTypes = statuses;
  },
  setStatusDropdownOptions: (state, statusoptions) => {
    state.statusDropdownOptions = statusoptions;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
