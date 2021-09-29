import { createStore } from 'vuex';
import projects from './modules/projects';



export const store = createStore({
    modules: {
        projects
    }
});
