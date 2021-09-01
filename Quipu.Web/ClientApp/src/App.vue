<template>
    <q-layout view="lHh Lpr lFf">      

        <q-drawer v-model="leftDrawerOpen"
                  show-if-above
                  bordered>
            <q-list>

                <div class="row" style="align-items:center" >
                    <q-item-label header>Quipu</q-item-label>
                    <q-space />
                    <div style="height:fit-content">
                        
                        <q-btn flat
                               dense
                               round
                               @click="leftDrawerOpen = false"
                               aria-label="Menu"
                               v-show="leftDrawerOpen"
                               icon="mdi-backburger" />
                    </div>
                </div>
                <q-item dense clickable @click="this.$router.push('/Home')">
                    <q-item-section avatar>
                        <q-icon name="o_school" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Home</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable :to="{name: 'MyTasks'}"  >
                    <q-item-section avatar>
                        <q-icon name="o_code" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>My Tasks</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Inbox')">
                    <q-item-section avatar>
                        <q-icon name="o_chat" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Inbox</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Reporting')">
                    <q-item-section avatar>
                        <q-icon name="o_forum" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Reporting</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Goals')">
                    <q-item-section avatar>
                        <q-icon name="o_rss_feed" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Goals</q-item-label>
                    </q-item-section>
                </q-item>
            </q-list>

            <q-separator />

            <q-expansion-item label="Favorites">

            </q-expansion-item>

            <q-separator />
        </q-drawer>

        <q-page-container>
            <router-view @open-nav ="openNav" :leftDrawerOpen="leftDrawerOpen" />
        </q-page-container>
    </q-layout>
</template>

<style scoped>
    .q-item__label--header {
        font-size: 20px;
    }

    .q-list {
        padding: 10px 20px 20px 20px;
    }

    .q-item__section--avatar {
        min-width: 0px;
    }
</style>

<script>

    export default {
        name: 'LayoutDefault',
        data() {
            return {
                leftDrawerOpen: true
            }
        },
        methods: {
            openNav() {
                this.leftDrawerOpen = true;
            }
        },

    }
        
    
</script>
