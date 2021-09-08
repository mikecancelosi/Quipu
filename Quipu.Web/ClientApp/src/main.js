import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { Quasar } from 'quasar'
import quasarUserOptions from './quasar-user-options'
import VueDraggable from "vuedraggable"

const app = createApp(App).use(Quasar, quasarUserOptions)

app.use(router)
app.use(VueDraggable)

app.mount('#app')


