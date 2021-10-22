import DiscussionRepository from './../../repositories/DiscussionRepository'

const state = {
    discussions :[],
};

const getters = {
    getDiscussions: (state) => state.discussions,
    getTaskDiscussion: (state) => (taskid) => {
        return state.discussions.filter(x => x.RecordID === taskid);
    },
    
};

const actions = {
    async fetchDiscussions({ commit }) {
        const discussionlist = (await DiscussionRepository.get()).data;
        commit('setDiscussions', discussionlist);
    }
};

const mutations = {
    setDiscussions: (state, discussionlist) => { state.discussions = discussionlist },
};

export default {
    state,
    getters,
    actions,
    mutations
};