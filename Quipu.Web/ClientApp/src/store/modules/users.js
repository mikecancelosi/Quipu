import UserRepository from './../../repositories/UserRepository'

const state = {
    users: [],
    userDropdownOptions: [],
};

const getters = {
    allUsers: (state) => state.users,
    allUserDropdownOptions(state) { return state.userDropdownOptions },
    getUserByID: (state) => (id) => {return state.users.find(x=>x.id === id)}
};

const actions = {
    async fetchUsers({ commit }) {
        const users = (await UserRepository.get()).data;
        const useroptions = [];
        users.forEach(user => {
            useroptions.push({
                label: user.display_Name,
                value: user,
                category: user.id,
            });
        });
        commit('setUsers', users);
        commit('setUserDropdownOptions', useroptions);
    },

    updateUser(user, { commit }) {
        UserRepository.post(user)
            .then(userinstance => commit('updateUser', userinstance))
            .catch(errorData => alert(errorData.message));
    }

};

const mutations = {
    setUsers: (state, users) => { state.users = users },
    setUserDropdownOptions: (state, useroptions) => { state.userDropdownOptions = useroptions },
    updateUser: (state, user) => {
        const index = state.users.findIndex(x => x.id === user.id);
        if (index !== -1) {
            state.users[index] = user;
        } else {
            state.users.add(user);
        }
    },
};

export default {
    state,
    getters,
    actions,
    mutations
};