<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false"
         v-if="loaded">
        <q-btn icon="o_person_outline"
               round
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     newuser == null"
               @click="assignUserClicked()"
               :style="{ visibility: newuser == null
                                             ? 'visible'
                                             : 'collapse'}" />

        <q-select dense
                  ref="userselect"
                  v-model="newuser"
                  :hide-dropdown-icon="!hover && !showdropdown"
                  :options="allUserDropdownOptions"
                  @update:model-value="updatetask()"
                  @popup-hide="showdropdown = false"
                  v-if="showdropdown ||  newuser != null"
                  borderless
                  emit-value>
            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        {{scope.opt.label}}
                    </q-item-section>
                </q-item>
            </template>

            <template v-slot:selected>
                {{newuser != null ? newuser.display_Name : ''}}
            </template>
        </q-select>


    </div>
</template>

<style scoped>
    .cell{
        width:100%;
        height:100%;
    }

</style>

<script>
    import { mapGetters, mapActions } from 'vuex'
    import { ref, reactive } from 'vue'
    import { RepositoryFactory } from '../../repositories/RepositoryFactory'
    const UserRepo = RepositoryFactory.get('users')

    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        computed: mapGetters(['allUsers', 'allUserDropdownOptions']),
        created() {
            this.fetchUsers();
        },
        props: {
            userid: {},
        },
        setup(props) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newuser = reactive({});
            const loaded = ref(false);

            console.log(props);
            if (props.userid != null) {


                (async () => {
                    const res = await UserRepo.getById(props.userid);
                    newuser.value = res.data;
                    loaded.value = true;
                })();
            }

            const assignUserClicked = () => {
                this.showdropdown = true;
                this.$nextTick(() => { this.$refs.userselect.showPopup() });
            };
            const updatetask = () => {
                this.$emit("update-task", this.newuser);
            };

            return { hover,loaded, showdropdown, newuser, assignUserClicked, updatetask}
        },
        methods: {
            
            ...mapActions(['fetchUsers']),
        },

    }
</script>