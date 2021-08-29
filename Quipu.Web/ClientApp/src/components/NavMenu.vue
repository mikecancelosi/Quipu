<template>
    <v-app>
        <v-navigation-drawer>

            <v-list-item>
                <v-list-item-content>
                    <v-list-item-title class="text-h6">Quipu</v-list-item-title>
                </v-list-item-content>
            </v-list-item>

            <v-divider />

            <v-list dense nav>
                <v-list-item @click=" this.$router.push('/Home')">

                    <v-list-item-icon>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>Home</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item @click=" this.$router.push('/Projects')">

                    <v-list-item-icon>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>My Tasks</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item @click=" this.$router.push('/Projects')">

                    <v-list-item-icon>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>Inbox</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item @click=" this.$router.push('/Projects')">

                    <v-list-item-icon>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>Reporting</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item @click=" this.$router.push('/Projects')">

                    <v-list-item-icon>
                        <v-icon>mdi-format-list-bulleted</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>Goals</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>            

            <v-divider />

            <div>
                <h2>Favorites</h2>
            </div>
            <v-divider />

            <div>
                <h2>Teams</h2>
            </div>
            <v-divider />

            <v-footer>
                   <h2>Help</h2>
            </v-footer>
        </v-navigation-drawer>
    </v-app>
</template>


<style scoped>
    .container {
        text-align: left;
        padding: 15px;
        margin: 0 0 0 0;
        max-width: 250px;
    }

    h2 {
        font-size: 16px;
    }

    .align-bottom {
        position: absolute;
        bottom: 10px;
        left: 100px;
    }
    .v-navigation-drawer{
       
    }

    
</style>

<script>
    export default {
        name: "NavMenu",
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>