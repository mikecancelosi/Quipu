<template>
    <q-page>
        <q-header style="background-color:transparent">
            <q-toolbar>
                <q-btn flat
                       dense
                       round
                       @click="openNav"
                       aria-label="Menu"
                       v-show="!this.leftDrawerOpen"
                       icon="mdi-forwardburger" />

            </q-toolbar>
        </q-header>


        <div id="page-container">
            <h1> New Team </h1>
            <q-input color="teal" filled label="Name" v-model="name"/>
            <q-space />
            <q-input color="teal" filled label="Description" type="textarea" v-model="description"/>
            <q-space />
            <div class="row">
                <q-list v-for="member in members" :key="member">
                    <q-icon flat
                            round
                            name="o_face"
                            style="margin-right:5px; font-size:32px;" />
                </q-list>
                <div v-if="members.length > 0">
                    <v-separator/>
                </div >
                <q-btn color="teal"
                       outline
                       no-caps
                       icon="o_add" 
                       label="Invite people" 
                       style="padding:4px 8px;" 
                       @click="invitepeople = true" />
            </div>
            <q-space />
            <div class="row">
                <q-space />
                <q-btn label="Create team" color="teal" :disable=canCreate @click="createTeam" />
            </div>

            <q-dialog v-model="invitepeople" >
                <q-card>
                    <q-card-section class="row items-center q-pb-none">
                        <div class="text-h6">Invite Members</div>
                        <q-space />
                        <q-btn icon="o_close" flat round dense v-close-popup />
                    </q-card-section>
                    <q-separator />
                    <q-card-section>
                        <q-input color="teal"
                                 outline label="Email addresses"
                                 placeholder="name@company.com, name@company.com, ..."
                                 typeof="textarea"
                                 v-model="addresses"
                                 type="textarea" />
                    </q-card-section>
                    <q-card-section>
                        <div class="row">
                            <q-space />
                            <q-btn label="OK" color="teal" @click="addUsers" v-close-popup />
                        </div>
                    </q-card-section>
                </q-card>
            </q-dialog>
        </div>

        
    </q-page>
</template>

<style scoped>
    h1 {
        font-size: 32px;
    }

    #page-container {
        position: relative;
        width: 100%;
        height: 100%;
        padding: 100px 300px;
    }

    .q-space {
        height: 25px;
    }

    .q-item-section--side {
        min-width: 0px;
    }

    .q-card{
        min-width:500px;
        min-height:200px;
    }
</style>


<script>
    import axios from 'axios'
    export default {
        name: "TeamCreate",
        props: {
            leftDrawerOpen: Boolean,
        },
        data() {
            return {
                name: "",
                description: "",
                members: [],
                invitepeople: false,
                addresses: "",
            }
        },
        methods: {
            openNav() {
                this.$emit("open-nav");
            },
            addUsers() {
                var addressArray = this.addresses.split(',');

                axios.get('http://127.0.0.1:5000/api/Users')
                    .then((response) => {
                        response.data.forEach(datum => {
                            //Not efficient
                            var match = addressArray.find(function (add) { return add === datum.login; });
                            if (match) {
                                this.members.push(datum);
                            }
                        });
                    })
                    .catch(function (error) {
                        alert(error);
                    });

                this.invitepeople = false;
                this.addresses = "";
            },
            createTeam() {
                let newId= axios.post('http://127.0.0.1:5000/api/Teams', {
                            Name: this.name,
                            Description: this.description,
                            Users: this.members
                });

                this.$route.push("/Teams/" + newId);

            }
        },
        computed: {
            canCreate() {
                if (this.name === "" || this.description === "") {
                    return true;
                }
                return false;
            },
        },
        mounted() {

        }
    }
</script>