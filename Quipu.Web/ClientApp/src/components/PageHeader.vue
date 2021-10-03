<template>
    <q-toolbar id="headingContainer">
        <q-btn flat
               dense
               round
               @click="toggleLeftDrawerOpen"
               aria-label="Menu"
               v-show="!this.leftDrawerOpen"
               icon="mdi-forwardburger" />
        <div class="row"
             style="align-items:center;">

            <q-btn id="headerIcon" :icon="icon" size="24px" dense flat />
            <a id="headerTitle" >
                {{title}}
            </a>
        </div>

        <q-tabs id="tabsContainer" v-if="hasTabs" dense >
            <div v-for="tab in tabs" :key="tab">
                <div v-if="tab.disable">
                    <q-tab disable>
                        {{tab.title}}
                    </q-tab>
                </div>

                <div v-if="!tab.disable">
                    <q-tab @click="this.$router.push(tab.link)">
                        {{tab.title}}
                    </q-tab>
                </div>
            </div>         

        </q-tabs>
    </q-toolbar>
</template>

<style scoped>
    #headingContainer{
        height:70px;
    }

    #tabsContainer{
        position:absolute;
        bottom:0;
    }

    #headerIcon {
        margin-right: 15px;
        padding: 0px;
    }

    #headerTitle {
        font-size: 24px
    }

</style>

<script>
    import { mapGetters, mapActions } from 'vuex'
    import {computed} from 'vue'
    export default {
        name: "PageHeader",
        setup(props) {
            const hasTabs = computed(() => props.tabs?.length ?? 0 > 0);

            return {hasTabs}
        },
        computed: mapGetters(['leftDrawerOpen']),
        props: {           
            title: String,
            icon: String,
            tabs:[],
        },
        data() {
            return {
                project: {},
            }
        },
        methods: {
            ...mapActions(['toggleLeftDrawerOpen']),
        },
    }
</script>