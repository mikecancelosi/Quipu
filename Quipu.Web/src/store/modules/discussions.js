import DiscussionRepository from "./../../repositories/DiscussionRepository";

const state = {
  discussions: [],
};

const getters = {
  getDiscussions: (state) => state.discussions,
  getTaskDiscussion: (state) => (taskid) => {
    return state.discussions.filter((x) => x.RecordID === taskid);
  },
};

const actions = {
  async fetchDiscussions({ commit }) {
    const discussionlist = (await DiscussionRepository.get()).data;
    commit("setDiscussions", discussionlist);
  },

  async postDiscussion({ commit }, discussion) {
    return DiscussionRepository.post(discussion)
      .then((instance) =>
        commit("postDiscussion", JSON.parse(instance.config.data))
      )
      .catch((errorData) => alert(errorData.message));
  },
};

const mutations = {
  setDiscussions: (state, discussionlist) => {
    state.discussions = discussionlist;
  },
  postDiscussion: (state, discussion) => {
    state.discussions.push(discussion);
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
