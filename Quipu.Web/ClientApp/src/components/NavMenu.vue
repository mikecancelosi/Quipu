<template>
    <v-navigation-drawer :model-value="this.isExpanded">
        <div class="title-nav">

            <v-list-item-title class="text-h6">Quipu</v-list-item-title>
            <v-spacer />
            <div class="btn-right">
                <v-btn icon="mdi-backburger" @click="this.collapse" />
            </div>


        </div>

        <v-list dense nav>
            <v-list-item @click=" this.$router.push('/Home')">

                <v-list-item-icon>
                    <v-icon nav-item-icon>mdi-home-outline</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title>Home</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

            <v-list-item @click=" this.$router.push('/MyTasks')">

                <v-list-item-icon>
                    <v-icon nav-item-icon>mdi-check-circle-outline</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title>My Tasks</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

            <v-list-item @click=" this.$router.push('/Projects')">

                <v-list-item-icon>
                    <v-icon nav-item-icon>mdi-bell-outline</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title>Inbox</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

            <v-list-item @click=" this.$router.push('/Projects')">

                <v-list-item-icon>
                    <v-icon nav-item-icon>mdi-chart-timeline-variant</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title>Reporting</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

            <v-list-item @click=" this.$router.push('/Projects')">

                <v-list-item-icon>
                    <v-icon nav-item-icon>mdi-shape-outline</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title>Goals</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </v-list>

        <v-divider />

        <v-list>
            <h2>Favorites</h2>

            <v-list-item>

                <v-list-item-icon>
                    <v-icon nav-item-icon-small>mdi-star-outline</v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <p>Star projects for easy access</p>
                </v-list-item-content>
            </v-list-item>

        </v-list>
        <v-divider />

        <v-list>
            <h2>Teams</h2>


        </v-list>
        <v-divider />

        <v-footer>
            <h2>Help</h2>
        </v-footer>
    </v-navigation-drawer>
</template>


<script>
    export default {
        name: "NavMenu",
        props: {
            isExpanded: Boolean
        },
        methods: {
            collapse() {
                this.$emit('collapse-nav');
            },
        }
    }
</script>

<style scoped>
    p {
        font-size: 12px;
    }

    h2 {
        font-size: 14px;
        text-align: left;
        font-weight: 600;
    }

    .title-nav {
        display: flex;
        align-items: center;
        width: 100%;
    }

    .btn-right {
        float: right;
    }

    .text-h6 {
        float: left;
        position: relative;
    }

    .align-bottom {
        position: absolute;
        bottom: 10px;
        left: 100px;
    }

    .v-navigation-drawer {
        padding: 30px 20px;
    }

    .v-list-item {
        padding: 0px;
    }

    .v-icon {
        font-size: 32px;
    }

        .v-icon[nav-item-icon] {
            font-size: 24px;
            margin-right: 5px;
        }

        .v-icon[nav-item-icon-small] {
            font-size: 20px;
            margin-right: 5px;
        }

    .v-list-item-title {
        font-size: 14px;
    }

    .v-list--density-default.v-list--one-line .v-list-item {
        min-height: 0;
        padding: 10px 0;
    }

    .v-list {
        padding: 20px 0;
    }

    .v-footer {
        position: absolute;
        bottom: 0;
        text-align: center;
    }

    .v-divider {
        position: absolute;
        left: 0;
        right: 0;
    }
</style>
