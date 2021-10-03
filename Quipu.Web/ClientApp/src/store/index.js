import { createStore } from 'vuex';
import projects from './modules/projects';
import common from './modules/common'



export const store = createStore({
    modules: {
        projects,
        common
    }
});
