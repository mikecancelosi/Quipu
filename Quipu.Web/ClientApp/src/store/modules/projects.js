import axios from 'axios';

const state = {
    users: [],
    userDropdownOptions: [],
    statusTypes: [],
    statusDropdownOptions: [],
    priorityTypes: [],
    priorityDropdownOptions: [],
};

const getters = {
    allUsers: (state) => state.users,
   
    allPriorityTypes: (state) => state.priorityTypes,
    allPriorityDropdownOptions: (state) => state.priorityDropdownOptions,
    allStatusTypes: (state) => state.statusTypes,
    allStatusDropdownOptions: (state) => state.statusDropdownOptions,
    allUserDropdownOptions(state) { return state.userDropdownOptions }
};

const actions = {
    async fetchUsers({ commit }) {
        const response = await axios.get('http://127.0.0.1:5000/api/Users');
        const useroptions = [];
        response.data.forEach(user => {
             useroptions.push({
                label: user.display_Name,
                value: user,
                category: user.id,
            });
        });
        commit('setUsers', response.data);
        commit('setUserDropdownOptions', useroptions);
    },
    async fetchPriorityTypes({ commit }) {
        const priorityoptions = [];
        const priorities = (await axios.get('http://127.0.0.1:5000/api/PriorityTypes')).data;
        priorities.forEach(priority => {
                 priorityoptions.push({
                     label: priority.name,
                     value: priority,
                     category: priority.id,
                 });
        });
        commit('setPriorityTypes', priorities);
        commit('setPriorityDropdownOptions', priorityoptions);
    },
    async fetchStatusTypes({ commit }) {
        const statusoptions = [];
        const statuses = (await axios.get('http://127.0.0.1:5000/api/StatusTypes')).data;
            
        statuses.forEach(status => {
            statusoptions.push({
                label: status.name,
                value: status,
                category: status.id,
            });
        });

        commit('setStatusTypes', statuses);
        commit('setStatusDropdownOptions', statusoptions);
    }
};

const mutations = {
    setUsers: (state, users) => { state.users = users },
    setUserDropdownOptions: (state, useroptions) => { state.userDropdownOptions = useroptions },
    setStatusTypes: (state, statuses) => { state.statusTypes = statuses },
    setStatusDropdownOptions: (state, statusoptions) => {
        state.statusDropdownOptions = statusoptions
    },
    setPriorityTypes: (state, priorities) => { state.priorityTypes = priorities },
    setPriorityDropdownOptions: (state, options) => { state.priorityDropdownOptions = options },
    
};

export default {
    state,
    getters,
    actions,
    mutations
};